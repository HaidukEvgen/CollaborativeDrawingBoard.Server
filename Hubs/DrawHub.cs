using Azure.Identity;
using CollaborativeDrawingBoard.Server.Models;
using CollaborativeDrawingBoard.Server.Services;
using Microsoft.AspNetCore.SignalR;
using System.Drawing;

namespace CollaborativeDrawingBoard.Server.Hubs
{
    public class DrawHub : Hub
    {
        private readonly IDrawingBoardService _drawingBoardService;
        private static Dictionary<string, string> _usersConnectedToBoard = new Dictionary<string, string>();

        public DrawHub(IDrawingBoardService drawingBoardService)
        {
            _drawingBoardService = drawingBoardService;
        }

        public async Task AddStroke(int drawingBoardId, Point startPoint, Point endPoint, string color)
        {
            await _drawingBoardService.AddStroke(drawingBoardId, startPoint, endPoint, color);
            string groupName = drawingBoardId.ToString();
            await Clients.OthersInGroup(groupName).SendAsync("newStroke", new { drawingBoardId, startPoint, endPoint, color });
        }

        public async Task<IEnumerable<BoardWithUsers>> GetBoards()
        {
            var drawingBoards = await _drawingBoardService.GetAllBoards();
            return drawingBoards.Select(board => new BoardWithUsers
            {
                Id = board.Id,
                Name = board.Name,
                Usernames = _usersConnectedToBoard
                    .Where(keyVal => keyVal.Value == board.Id.ToString())
                    .Select(keyVal => keyVal.Key)
            });
        }

        public async Task JoinBoard(int drawingBoardId, string username)
        {
            string groupName = drawingBoardId.ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            _usersConnectedToBoard[username] = groupName;
            await Clients.All.SendAsync("userJoinedBoard", drawingBoardId, username);
        }

        public async Task LeaveBoard(int drawingBoardId, string username)
        {
            string groupName = drawingBoardId.ToString();
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            _usersConnectedToBoard.Remove(username);
            await Clients.All.SendAsync("userLeftBoard", drawingBoardId, username);
        }

        public async Task CreateBoard(string boardName)
        {
            BoardWithUsers newBoard = await _drawingBoardService.CreateBoard(boardName);
            await Clients.All.SendAsync("newBoardAdded", newBoard);
        }
    }
}

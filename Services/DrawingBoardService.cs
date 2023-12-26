using CollaborativeDrawingBoard.Server.Models;
using CollaborativeDrawingBoard.Server.Repositories;
using System.Drawing;

namespace CollaborativeDrawingBoard.Server.Services
{
    public class DrawingBoardService : IDrawingBoardService
    {
        private readonly IDrawingBoardRepository _drawingBoardRepository;

        public DrawingBoardService(IDrawingBoardRepository drawingBoardRepository)
        {
            _drawingBoardRepository = drawingBoardRepository;
        }

        public async Task AddStroke(int drawingBoardId, Point startPoint, Point endPoint, string color)
        {

            var stroke = new Stroke
            {
                StartPointX = startPoint.X,
                StartPointY = startPoint.Y,
                EndPointX = endPoint.X,
                EndPointY = endPoint.Y,
                Color = color
            };

            await _drawingBoardRepository.AddStrokeToDrawingBoard(drawingBoardId, stroke);
        }

        public async Task<List<StrokeDrawingInfo>> GetAllStrokesByBoardId(int drawingBoardId)
        {
            var drawingBoard = await _drawingBoardRepository.GetDrawingBoardWithStrokesById(drawingBoardId);
            if (drawingBoard == null)
            {
                return null;
            }

            return drawingBoard.Strokes.Select(s => new StrokeDrawingInfo
            {
                StartPointX = s.StartPointX,
                StartPointY = s.StartPointY,
                EndPointX = s.EndPointX,
                EndPointY = s.EndPointY,
                Color = s.Color
            }).ToList();
        }

        public async Task<List<DrawingBoard>> GetAllBoards()
        {
            return await _drawingBoardRepository.GetAllDrawingBoards();
        }

        public async Task<BoardWithUsers> CreateBoard(string boardName)
        {
            var newBoard = new DrawingBoard
            {
                Name = boardName,
            };
            
            var boardId = await _drawingBoardRepository.CreateDrawingBoard(newBoard);

            return new BoardWithUsers
            {
                Id = boardId,
                Name = boardName,
                Usernames = []
            };
        }
    }
}

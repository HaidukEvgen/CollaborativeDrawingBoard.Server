using CollaborativeDrawingBoard.Server.Models;
using System.Drawing;

namespace CollaborativeDrawingBoard.Server.Services
{
    public interface IDrawingBoardService
    {
        Task AddStroke(int drawingBoardId, Point startPoint, Point endPoint, string color);
        Task<List<StrokeDrawingInfo>> GetAllStrokesByBoardId(int drawingBoardId);
        Task<List<DrawingBoard>> GetAllBoards();
        Task<BoardWithUsers> CreateBoard(string boardName);
    }
}

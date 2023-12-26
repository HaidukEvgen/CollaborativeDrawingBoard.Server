using CollaborativeDrawingBoard.Server.Models;

namespace CollaborativeDrawingBoard.Server.Repositories
{
    public interface IDrawingBoardRepository
    {
        public Task<DrawingBoard> GetDrawingBoardById(int id);
        Task<DrawingBoard> GetDrawingBoardWithStrokesById(int id);
        public Task<List<DrawingBoard>> GetAllDrawingBoards();
        public Task<int> CreateDrawingBoard(DrawingBoard drawingBoard);
        public Task AddStrokeToDrawingBoard(int drawingBoardId, Stroke stroke);
    }
}

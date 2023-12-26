using CollaborativeDrawingBoard.Server.Data;
using CollaborativeDrawingBoard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeDrawingBoard.Server.Repositories
{
    public class DrawingBoardRepository : IDrawingBoardRepository
    {
        private readonly AppDbContext _dbContext;

        public DrawingBoardRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DrawingBoard> GetDrawingBoardById(int id)
        {
            return await _dbContext.DrawingBoards.FindAsync(id);
        }

        public async Task<DrawingBoard> GetDrawingBoardWithStrokesById(int id)
        {
            return await _dbContext.DrawingBoards.Include(db => db.Strokes).FirstOrDefaultAsync(db => db.Id == id);
        }

        public async Task<List<DrawingBoard>> GetAllDrawingBoards()
        {
            return await _dbContext.DrawingBoards.ToListAsync();
        }

        public async Task<int> CreateDrawingBoard(DrawingBoard drawingBoard)
        {
            var board = _dbContext.DrawingBoards.Add(drawingBoard);
            await _dbContext.SaveChangesAsync();
            return board.Entity.Id;
        }

        public async Task AddStrokeToDrawingBoard(int drawingBoardId, Stroke stroke)
        {
            var drawingBoard = await _dbContext.DrawingBoards.FindAsync(drawingBoardId);
            if (drawingBoard != null)
            {
                drawingBoard.Strokes.Add(stroke);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

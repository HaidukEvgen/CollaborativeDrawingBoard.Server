using CollaborativeDrawingBoard.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CollaborativeDrawingBoard.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DrawingBoard> DrawingBoards { get; set; }

        public DbSet<Stroke> Strokes { get; set; }
    }
}

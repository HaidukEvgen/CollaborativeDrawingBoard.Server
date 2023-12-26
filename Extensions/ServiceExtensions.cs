using CollaborativeDrawingBoard.Server.Data;
using CollaborativeDrawingBoard.Server.Repositories;
using CollaborativeDrawingBoard.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeDrawingBoard.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMsSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DrawingBoardDb");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IDrawingBoardService, DrawingBoardService>();
            services.AddScoped<IDrawingBoardRepository, DrawingBoardRepository>();
        }
    }
}

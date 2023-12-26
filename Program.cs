using CollaborativeDrawingBoard.Server.Extensions;
using CollaborativeDrawingBoard.Server.Hubs;
using CollaborativeDrawingBoard.Server.Services;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.ConfigureMsSqlServerContext(builder.Configuration);
builder.Services.ConfigureBusinessServices();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors();

app.MapHub<DrawHub>("/drawHub");

app.MapGet("/drawingboards/{drawingBoardId}/strokes", async (int drawingBoardId, IDrawingBoardService drawingBoardService) =>
{
    var strokes = await drawingBoardService.GetAllStrokesByBoardId(drawingBoardId);
    if (strokes == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(strokes);
});


app.Run();
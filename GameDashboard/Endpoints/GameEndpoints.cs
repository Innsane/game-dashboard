using GameDashboard.Database;
using GameDashboard.Dtos;
using GameDashboard.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameDashboard.Endpoints;

public static class GameEndpoints
{
    public static IEndpointRouteBuilder MapGameEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/games")
            .WithTags("Games")
            .WithOpenApi();

        group.MapGet("/", async (AppDbContext db) =>
            await db.Games.AsNoTracking().ToListAsync());

        group.MapGet("/{id:int}", async (Guid id, AppDbContext db) =>
            await db.Games.FindAsync(id) is { } g 
                ? Results.Ok(g) 
                : Results.NotFound());

        group.MapPost("/", async (GameDto dto, AppDbContext db) =>
        {
            var game = new Game
            {
                Title = dto.Title,
                Platform = dto.Platform,
                Released = dto.Released
            };
            
            db.Games.Add(game);
            await db.SaveChangesAsync();
            
            return Results.Created($"/api/games/{game.Id}", game);
        });

        group.MapPut("/{id:int}", async (Guid id, GameDto dto, AppDbContext db) =>
        {
            var game = await db.Games.FindAsync(id);
            if (game is null)
            {
                return Results.NotFound();
            }

            game.Title = dto.Title;
            game.Platform = dto.Platform;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        return routes;
    }
}


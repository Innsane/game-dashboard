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

        group.MapGet("/", async (AppDbContext context) =>
            await context.Games.AsNoTracking().ToListAsync());

        group.MapGet("/{id:int}", async (int id, AppDbContext context) =>
            await context.Games.FindAsync(id) is { } g 
                ? Results.Ok(g) 
                : Results.NotFound());

        group.MapPost("/", async (GameDto dto, AppDbContext context) =>
        {
            var game = new Game
            {
                Title = dto.Title,
                Platform = dto.Platform,
                Released = dto.Released
            };
            
            context.Games.Add(game);
            await context.SaveChangesAsync();
            
            return Results.Created($"/api/games/{game.Id}", game);
        });

        group.MapPut("/{id:int}", async (int id, GameDto dto, AppDbContext context) =>
        {
            var game = await context.Games.FindAsync(id);
            if (game is null)
            {
                return Results.NotFound();
            }

            game.Title = dto.Title;
            game.Platform = dto.Platform;

            await context.SaveChangesAsync();
            return Results.NoContent();
        });

        return routes;
    }
}


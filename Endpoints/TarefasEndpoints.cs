using Dapper.Contrib.Extensions;
using MinimalAPICore.Data;
using static MinimalAPICore.Data.TarefaContext;

namespace MinimalAPICore.Endpoints;

public static class TarefasEndpoints
{
    public static void MapTarefasEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => $"Bem vindo a Minimal API - Tarefas = {DateTime.Now}");

        app.MapGet("/tarefas", async (GetConnection conexao) =>
        {
            using var con = await conexao();
            var tarefas = con.GetAll<Tarefa>().ToList();

            if (tarefas is null)
                return Results.NotFound();

            return Results.Ok(tarefas);
        });

        app.MapGet("/tarefas/{id}", async (GetConnection conexao, int id) =>
        {
            using var con = await conexao();
            var tarefa = con.Get<Tarefa>(id);

            if (tarefa is null)
                return Results.NotFound(tarefa);

            return Results.Ok(tarefa);
        });

        app.MapPost("/tarefas", async (GetConnection conexao, Tarefa tarefa) =>
        {
            using var con = await conexao();
            var id = con.Insert<Tarefa>(tarefa);
            return Results.Created($"/tarefas/{id}", tarefa);
        });

        app.MapPut("/tarefas", async (GetConnection conexao, Tarefa tarefa) =>
        {
            using var con = await conexao();
            var id = con.Update<Tarefa>(tarefa);
            return Results.Ok();
        });

        app.MapDelete("/tarefas/{id}", async (GetConnection conexao, int id) =>
        {
            using var con = await conexao();
            var tarefa = con.Get<Tarefa>(id);

            if (tarefa is null)
                return Results.NotFound(tarefa);

            con.Delete<Tarefa>(tarefa);

            return Results.Ok(tarefa);
        });
    }
}

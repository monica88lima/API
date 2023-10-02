using ApiTarefas.Endpoints;
using ApiTarefas.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.addPersistence();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TarefasDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapTarefasEndpoints();
app.Run();
//app.UseHttpsRedirection();

//Codigo utilizado para utilizar cache, onde as operações ficavam na memoria

//app.MapGet("/tarefas", async (AppDbContext db) =>  await db.Tarefas.ToListAsync());

//app.MapGet("/tarefa/ID{id}", async (int id, AppDbContext db) => 
//                          await db.Tarefas.FindAsync(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound());


//app.MapGet("/tarefa/concluida", async (AppDbContext db) =>
//                          await db.Tarefas.Where(x => x.IsCompleted).ToListAsync());

//app.MapGet("/tarefa/Nome{título}", async (string nome, AppDbContext db) =>
//                          await db.Tarefas.Where(x => x.Nome.Contains(nome)).ToListAsync());

//app.MapPost("/tarefas", async (Tarefa tarefa, AppDbContext db) =>
//{
//    db.Tarefas.Add(tarefa);
//    await db.SaveChangesAsync();
//    return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
//});

//app.MapPut("/tarefas/{id}", async (int id, Tarefa inputTarefa, AppDbContext db) =>
//{
//    var tarefa = await db.Tarefas.FindAsync(id);
//    if(tarefa is null) return Results.NotFound();

//    tarefa.Nome = inputTarefa.Nome;
//    tarefa.IsCompleted = inputTarefa.IsCompleted;

//    await db.SaveChangesAsync();
//    return Results.NoContent();

//});

//app.MapDelete("/tarefas/{id}", async (int id, AppDbContext db) =>
//{
//    if (await db.Tarefas.FindAsync(id) is Tarefa tarefa)
//    {
//        db.Tarefas.Remove(tarefa);
//        await db.SaveChangesAsync();
//        return Results.Ok(tarefa);
//    }
//    return Results.NotFound();
//});



//class Tarefa
//{
//    public int Id { get; set; }
//    public string? Nome { get; set; }
//    public bool IsCompleted { get; set; }
//}

//class AppDbContext : DbContext
//{
//    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//    { }
//    public DbSet<Tarefa> Tarefas => Set<Tarefa>();
//}


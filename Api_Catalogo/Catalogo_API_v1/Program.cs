using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System.Text.Json.Serialization;
using Services;
using Catalogo_API_v1.Middleware;
using Catalogo_API_v1.Filtro;
using Catalogo_API_v1.Log;
using Repositorio.Interface;
using Repositorio;
using Dto.Mapeamento;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// adicionando filtro global para tratamento de erros
builder.Services.AddControllers(options => { options.Filters.Add(typeof(ApiExceptionFiltro)); }).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                                             options.UseMySql(mySqlConnection,
                                             ServerVersion.AutoDetect(mySqlConnection)));
builder.Services.AddAutoMapper(typeof(DtoMappingProfile));
builder.Services.AddTransient<IMeuServico, MeuServico>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ApiLoggingFiltro>();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerConfig
{
    LogLevel = LogLevel.Information
}));
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

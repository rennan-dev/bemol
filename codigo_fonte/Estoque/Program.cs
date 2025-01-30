using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Estoque.Data;
using Estoque.RabbitMqClient;
using Estoque.EventProcessor;
using Estoque.PedidoHttpClient;
//using Estoque.ItemServiceHttpClient;
//using Estoque.RabbitMqClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("EstoqueConnection");

builder.Services.AddDbContext<EstoqueContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();

builder.Services.AddHostedService<RabbitMqSubscriber>();

builder.Services.AddHttpClient<IPedidoHttpClient, PedidoHttpClient>();
builder.Services.AddSingleton<IProcessaEvento, ProcessaEvento>();

//builder.Services.AddHttpClient<IItemServiceHttpClient, ItemServiceHttpClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Estoque", Version = "v1" });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EstoqueContext>();
    db.Database.Migrate();
}

app.Run();

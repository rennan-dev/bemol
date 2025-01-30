using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pedido.Data;
using Pedido.Data.ItemPedidoRepository;
using Pedido.Data.PedidoRepository;
using Pedido.Data.ProdutoRepository;
using Pedido.EstoqueHttpClient;
using Pedido.RabbitMqClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PedidoConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();  
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddSingleton<IRabbitMqClient, RabbitMqClient>();

builder.Services.AddHttpClient<IEstoqueHttpClient, EstoqueHttpClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pedido", Version = "v1" });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();

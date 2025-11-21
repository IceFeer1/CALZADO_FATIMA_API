using AutoMapper;
using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Profiles;
using CALZADO_FATIMA_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//conexion a SQL Server
builder.Services.AddDbContext<CalzadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Para Productos
builder.Services.AddScoped<ProductoDAO>();
builder.Services.AddScoped<ProductoService>();

//Para pedidos
builder.Services.AddScoped<PedidoDAO>();
builder.Services.AddScoped<PedidoService>();

//Para proveedores
builder.Services.AddScoped<ProveedorDAO>();
builder.Services.AddScoped<ProveedorService>();

//para detalleventa
builder.Services.AddScoped<DetalleVentaDAO>();
builder.Services.AddScoped<DetalleVentaService>();

//para estadopedido
builder.Services.AddScoped<EstadoPedidoDAO>();
builder.Services.AddScoped<EstadoPedidoService>();

//para mantenimiento
builder.Services.AddScoped<MantenimientoDAO>();
builder.Services.AddScoped<MantenimientoService>();

//para recibe 
builder.Services.AddScoped<RecibeDAO>();
builder.Services.AddScoped<RecibeService>();

//para suministra
builder.Services.AddScoped<SuministraDAO>();
builder.Services.AddScoped<SuministraService>();

//para tipo pedidos
builder.Services.AddScoped<TipoPedidoDAO>();
builder.Services.AddScoped<TipoPedidoService>();

//para ventas
builder.Services.AddScoped<VentaDAO>();
builder.Services.AddScoped<VentaService>();

//para solucionar errores
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ClienteDAO>();


//mapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
// Add services to the container.

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Dev");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

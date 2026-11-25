using Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TiendaRopaDb");

builder.Services.AddScoped<IPrendaRepository, PrendaRepository>(provider =>
    new PrendaRepository(connectionString!));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>(provider =>
    new ClienteRepository(connectionString!));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>(provider =>
    new PedidoRepository(connectionString!));

builder.Services.AddScoped<IEnvioRepository, EnvioRepository>(provider =>
    new EnvioRepository(connectionString!));

builder.Services.AddScoped<ILineaPedidoRepository, LineaPedidoRepository>(provider =>
    new LineaPedidoRepository(connectionString!));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

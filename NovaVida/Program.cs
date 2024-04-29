using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NovaVida;
using NovaVidaInfra.Common;
using NovaVidaRepository.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Configurar o Entity Framework para design-time (migrações)
string conn2 = builder.Configuration.GetConnectionString("App");
builder.Services.AddDbContext<DbContextApplication>(options => options.UseMySql(conn2, ServerVersion.AutoDetect(conn2)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CadastroApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


DependencyInjection.Register(builder.Services);


builder.Services.AddControllers();

// Aprenda mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var registerSeeds = services.GetRequiredService<SeedsRunner>();
        await registerSeeds.InitializeAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CadastroApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
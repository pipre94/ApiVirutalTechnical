using Infrastructure.Context;
using Application;
using Domain.Interfaces;
using Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<VirtualRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    return new VirtualRepository(connectionString);
});

// Add services to the container.
builder.Services.AddScoped<IVirtualServices, VirtualServices>();

builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEverything",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowEverything");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

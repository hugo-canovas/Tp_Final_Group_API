using Microsoft.EntityFrameworkCore;
using tp_app_back.Data;
using tp_app_back.Interfaces;
using tp_app_back.Services;

var builder = WebApplication.CreateBuilder(args);

//Connection SQL with Lazy Loading
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

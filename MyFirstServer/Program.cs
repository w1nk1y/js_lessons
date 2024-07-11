using Microsoft.EntityFrameworkCore;
using MyFirstServer.Interfaces;
using MyFirstServer.Services;
using MyFirstServer.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddDbContext<ApplicationDbContext>(optionsAction: options =>
options.UseNpgsql(builder.Configuration.GetConnectionString(name: "ApplicationDbContext")));
builder.Services.AddTransient<IPostsRepository, PostsRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    builder =>
    {
        builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpLogging();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();



app.Run();

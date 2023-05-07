using Amazon.S3;
using BackEndLS.IRepositories;
using BackEndLS.IServices;
using BackEndLS.Persistence.Context;
using BackEndLS.Repositories;
using BackEndLS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IAWSServices, AWSServices>();

builder.Services.AddScoped<IUserRepositories, UserRepositories>();
builder.Services.AddScoped<IAWSRepositories, AWSRepositories>();

builder.Services.AddAWSService<IAmazonS3>();

builder.Services.AddDbContext<LSContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                                        builder => builder.AllowAnyOrigin()
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()));

//builder.Services.AddScoped<IUserServices, UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

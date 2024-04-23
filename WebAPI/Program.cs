using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.QuizUserService;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Memory.Repository;
using Web;
using WebAPI.Dto;
using WebAPI.Validators;
using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<QuizItem>, QuizItemValidator>();
builder.Services.AddScoped<IValidator<NewQuizItemDto>, NewQuizItemDtoValidator>();




//builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
//builder.Services.AddSingleton<IQuizAdminService, QuizAdminService>();
builder.Services.AddDbContext<QuizDbContext>();                             
builder.Services.AddTransient<IQuizUserService, QuizUserServiceEF>();       
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
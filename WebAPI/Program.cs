using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.QuizUserService;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
//using Infrastructure.EF;
//using Infrastructure.EF.Services;
using Infrastructure.Memory.Repository;
using Web;
using WebAPI.Dto;
using WebAPI.Validators;

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
builder.Services.AddSingleton<IGenericRepository<QuizItem, int>, MemoryGenericRepository<QuizItem, int>>();
builder.Services.AddSingleton<IGenericRepository<Quiz, int>, MemoryGenericRepository<Quiz, int>>();
builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>, MemoryGenericRepository<QuizItemUserAnswer, string>>();

builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
builder.Services.AddSingleton<IQuizAdminService, QuizAdminService>();
// builder.Services.AddDbContext<QuizDbContext>();                             infrastructure
// builder.Services.AddTransient<IQuizUserService, QuizUserServiceEF>();       infrastructure
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
app.Seed();      
app.Run();
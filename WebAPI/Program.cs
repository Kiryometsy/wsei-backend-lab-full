using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.QuizUserService;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Services;
using Infrastructure.Memory.Repository;
using Web;
using WebAPI.Dto;
using WebAPI.Validators;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;
using Infrastructure.Entities;
using WebAPI.Configuration;
using Microsoft.OpenApi.Models;

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

builder.Services.AddSingleton<JwtSettings>();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(new JwtSettings(builder.Configuration));
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
              Enter 'Bearer' and then your token in the text input below.
              Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Quiz API",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.AddUsers();
app.MapControllers();
      
app.Run();
using Microsoft.EntityFrameworkCore;
using RESTFull.Domain;
using RESTFull.Service;
using RESTFull.Infrastructure;
using RESTFull.Service.gateway;
using RESTFull.Service.mapper;
using System;
using RESTFull.API.mapper;
using RESTFull.Service.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RESTFull.Infrastructure.Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<ConferenceFormToDtoMapper, ConferenceFormToDtoMapper>();
builder.Services.AddScoped<ParticipantFormToDtoMapper, ParticipantFormToDtoMapper>();
builder.Services.AddScoped<ReportFromToDtoMapper, ReportFromToDtoMapper>();
builder.Services.AddScoped<SectionFormToDtoMapper, SectionFormToDtoMapper>();
builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();
builder.Services.AddScoped<ISectionReporitory, SectionRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ConferenceMapper, ConferenceMapper>();
builder.Services.AddScoped<ParticipantMapper, ParticipantMapper>();
builder.Services.AddScoped<SectionMapper, SectionMapper>();
builder.Services.AddScoped<ReportMapper, ReportMapper>();
builder.Services.AddScoped<IConferenceService, ConferenceService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IReportService, ReportService>();

var app = builder.Build();

app.MapControllers();
//app.MapControllerRoute("ConferenceController", "conf");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();

    // Создание базы данных

    //context.Database.OpenConnection(); // Открытие соединения для базы в памяти

    //context.Database.EnsureCreated(); 
    //context.Database.Migrate();  // Создание схемы базы данны


    // Работа с базой данных
    context.SaveChanges();



}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

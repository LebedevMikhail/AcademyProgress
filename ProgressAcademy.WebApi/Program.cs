using MediatR;
using MongoDB.Driver;
using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Application.Commands.Mentee;
using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Application.Commands.Theme;
using ProgressAcademy.Application.Queries;
using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Application.Queries.Mentee;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Application.Queries.Theme;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Handlers.Commands.Theme;
using ProgressAcademy.Handlers.Queries;
using ProgressAcademy.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
builder.Services.AddSingleton<IMongoDatabase>(provider =>
{
    var mongoClient = provider.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase("test");
});

builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IRequestHandler<GetAllLessonsQuery, IEnumerable<Lesson>>, LessonQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetLessonByIdQuery, Lesson>, LessonQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreateLessonCommand>, LessonCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteLessonCommand>, LessonCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateLessonCommand>, LessonCommandHandler>();

builder.Services.AddTransient<IMenteeRepository, MenteeRepository>();
builder.Services.AddTransient<IRequestHandler<GetAllMenteesQuery, IEnumerable<Mentee>>, MenteeQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetMenteeByIdQuery, Mentee>, MenteeQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreateMenteeCommand>, MenteeCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteMenteeCommand>, MenteeCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateMenteeCommand>, MenteeCommandHandler>();

builder.Services.AddTransient<IMentorRepository, MentorRepository>();
builder.Services.AddTransient<IRequestHandler<GetAllMentorsQuery, IEnumerable<Mentor>>, MentorQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetMentorByIdQuery, Mentor>, MentorQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreateMentorCommand>, MentorCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteMentorCommand>, MentorCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateMentorCommand>, MentorCommandHandler>();

builder.Services.AddTransient<IPlanRepository, PlanRepository>();
builder.Services.AddTransient<IRequestHandler<GetAllPlansQuery, IEnumerable<Plan>>, PlanQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetPlanByIdQuery, Plan>, PlanQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreatePlanCommand>, PlanCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeletePlanCommand>, PlanCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdatePlanCommand>, PlanCommandHandler>();

builder.Services.AddTransient<IThemeRepository, ThemeRepository>();
builder.Services.AddTransient<IRequestHandler<GetAllThemesQuery, IEnumerable<Theme>>, ThemeQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetThemeByIdQuery, Theme>, ThemeQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreateThemeCommand>, ThemeCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteThemeCommand>, ThemeCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateThemeCommand>, ThemeCommandHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllMentorsQuery).Assembly));
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

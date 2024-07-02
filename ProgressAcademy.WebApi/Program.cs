using MediatR;
using MongoDB.Bson.Serialization;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Data.Config;
using ProgressAcademy.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddDataSeeders();

builder.Services.AddSingleton<MongoDbConfig>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllMentorsQuery).Assembly));

RegisterSerializers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<MongoDbConfig>();
    await initializer.SeedDataAsync();
}

app.Run();

/// <summary>
/// Registers custom serializers.
/// </summary>
void RegisterSerializers()
{
    BsonSerializer.RegisterSerializer(new MultipleChoiceQuestionSerializer());
}

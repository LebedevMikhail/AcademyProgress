using MongoDB.Driver;
using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Application.Commands.Mentee;
using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Application.Commands.Theme;
using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Application.Queries.Mentee;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Application.Queries.Theme;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Infrastructure.Repositories;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Handlers.Commands.Theme;
using ProgressAcademy.Handlers.Queries;
using ProgressAcademy.Domain.Models;
using MediatR;
using ProgressAcademy.Application.Queries;
using ProgressAcademy.Data.Config;
using ProgressAcademy.Data.Config.Seeds;

namespace ProgressAcademy.Infrastructure.Extensions
{
    /// <summary>
    /// Contains extension methods for registering services into the IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds MongoDB client and database services to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <param name="configuration">The application's configuration.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConnectionString = configuration["MONGO_DB_CONNECTION_STRING"];
            var database = configuration["MONGO_INITDB_DATABASE"];
            services.AddSingleton<IMongoClient, MongoClient>(_ =>
                        {
                            var mongoClientSettings = MongoClientSettings.FromConnectionString(mongoConnectionString);
                            return new MongoClient(mongoClientSettings);
                        });

            services.AddSingleton<IMongoDatabase>(provider =>
            {
                var mongoClient = provider.GetRequiredService<IMongoClient>();
                return mongoClient.GetDatabase(database);
            });

            return services;
        }

        /// <summary>
        /// Registers repository services into the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IMenteeRepository, MenteeRepository>();
            services.AddTransient<IMentorRepository, MentorRepository>();
            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddTransient<IThemeRepository, ThemeRepository>();

            return services;
        }

        /// <summary>
        /// Registers MediatR handlers into the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the handlers to.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetAllLessonsQuery, IEnumerable<Lesson>>, LessonQueryHandler>();
            services.AddTransient<IRequestHandler<GetLessonByIdQuery, Lesson>, LessonQueryHandler>();
            services.AddTransient<IRequestHandler<CreateLessonCommand>, LessonCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteLessonCommand>, LessonCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateLessonCommand>, LessonCommandHandler>();

            services.AddTransient<IRequestHandler<GetAllMenteesQuery, IEnumerable<Mentee>>, MenteeQueryHandler>();
            services.AddTransient<IRequestHandler<GetMenteeByIdQuery, Mentee>, MenteeQueryHandler>();
            services.AddTransient<IRequestHandler<CreateMenteeCommand>, MenteeCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteMenteeCommand>, MenteeCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateMenteeCommand>, MenteeCommandHandler>();

            services.AddTransient<IRequestHandler<GetAllMentorsQuery, IEnumerable<Mentor>>, MentorQueryHandler>();
            services.AddTransient<IRequestHandler<GetMentorByIdQuery, Mentor>, MentorQueryHandler>();
            services.AddTransient<IRequestHandler<CreateMentorCommand>, MentorCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteMentorCommand>, MentorCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateMentorCommand>, MentorCommandHandler>();

            services.AddTransient<IRequestHandler<GetAllPlansQuery, IEnumerable<Plan>>, PlanQueryHandler>();
            services.AddTransient<IRequestHandler<GetPlanByIdQuery, Plan>, PlanQueryHandler>();
            services.AddTransient<IRequestHandler<CreatePlanCommand>, PlanCommandHandler>();
            services.AddTransient<IRequestHandler<DeletePlanCommand>, PlanCommandHandler>();
            services.AddTransient<IRequestHandler<UpdatePlanCommand>, PlanCommandHandler>();

            services.AddTransient<IRequestHandler<GetAllThemesQuery, IEnumerable<Theme>>, ThemeQueryHandler>();
            services.AddTransient<IRequestHandler<GetThemeByIdQuery, Theme>, ThemeQueryHandler>();
            services.AddTransient<IRequestHandler<CreateThemeCommand>, ThemeCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteThemeCommand>, ThemeCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateThemeCommand>, ThemeCommandHandler>();

            return services;
        }

        /// <summary>
        /// Registers data seeders into the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the seeders to.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddDataSeeders(this IServiceCollection services)
        {
            services.AddTransient<DataSeeder, MenteeSeeder>();
            services.AddTransient<DataSeeder, MentorSeeder>();
            services.AddTransient<DataSeeder, PlanSeeder>();
            services.AddTransient<DataSeeder, LessonSeeder>();
            // services.AddTransient<DataSeeder, ThemeSeeder>();
            services.AddSingleton(provider => provider.GetServices<DataSeeder>().ToList());

            return services;
        }
    }
}

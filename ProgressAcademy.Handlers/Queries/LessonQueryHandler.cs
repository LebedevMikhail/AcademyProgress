using MediatR;
using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

/// <summary>
/// Handles queries for retrieving lesson information from the data store.
/// </summary>
public class LessonQueryHandler : 
             IRequestHandler<GetAllLessonsQuery, IEnumerable<Lesson>>, 
             IRequestHandler<GetLessonByIdQuery, Lesson>
{
    private readonly ILessonRepository _lessonRepository;
    
    /// <summary>
    /// Initializes a new instance of the LessonQueryHandler with a lesson repository.
    /// </summary>
    /// <param name="lessonRepository">The repository responsible for lesson data operations.</param>
    public LessonQueryHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    /// <summary>
    /// Handles the query to retrieve a single lesson by its identifier.
    /// </summary>
    /// <param name="query">The query containing the identifier of the lesson to retrieve.</param>
    /// <returns>A lesson object if found; otherwise, null.</returns>
    public async Task<Lesson> Handle(GetLessonByIdQuery query, CancellationToken cancellationToken)
    {
        if(query == null || query.LessonId == 0)
        {
            throw new ArgumentNullException($"GetLessonByIdQuery must not be null or the LessonID value is zero");
        }
        return await _lessonRepository.GetLessonByIdAsync(query.LessonId, cancellationToken);
    }

    /// <summary>
    /// Handles the query to retrieve all lessons.
    /// </summary>
    /// <param name="query">The query requesting all lessons.</param>
    /// <returns>An enumerable collection of Lesson objects.</returns>
    public async Task<IEnumerable<Lesson>> Handle(GetAllLessonsQuery query, CancellationToken cancellationToken)
    {
        if(query == null)
        {
            throw new ArgumentNullException($"GetAllLessonsQuery must not be null");
        }
        return await _lessonRepository.GetAllLessonsAsync(cancellationToken);
    }
}
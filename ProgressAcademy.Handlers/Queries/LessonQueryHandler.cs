using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

public class LessonQueryHandler
{
    private readonly ILessonRepository _lessonRepository;
    
    public LessonQueryHandler(
        ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public Lesson Handle(GetLessonByIdQuery query)
    {
        if(query == null || query.LessonId == 0)
        {
            throw new ArgumentNullException($"GetLessonByIdQuery must not be null or the LessonID value is zero ");
        }
        return  _lessonRepository.GetLessonById(query.LessonId);
    }

    public IEnumerable<Lesson> Handle(GetAllLessonsQuery query)
    {
        if(query == null )
        {
            throw new ArgumentNullException($"GetAllLessonsQuery must not be null");
        }
        return _lessonRepository.GetAllLessons();
    }
}
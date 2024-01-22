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
        return  _lessonRepository.GetLessonById(query.LessonId);
    }

    public IEnumerable<Lesson> Handle(GetAllLessonsQuery query)
    {
        return _lessonRepository.GetAllLessons();
    }
}
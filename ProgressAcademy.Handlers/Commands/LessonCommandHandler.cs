using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

public class LessonCommandHandler {
    private readonly ILessonRepository _lessonRepository;

    public LessonCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public void Handle(CreateLessonCommand command)
    {
        _lessonRepository.CreateLesson(command.Lesson);
    }

    public void Handle(UpdateLessonCommand command)
    {
        _lessonRepository.UpdateLesson(command.Lesson);
    }

    public void Handle(DeleteLessonCommand command)
    {
        _lessonRepository.DeleteLesson(command.LessonId);
    }
}
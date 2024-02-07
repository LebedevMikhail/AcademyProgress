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
        if(command == null)
        {
            throw new ArgumentNullException($"CreateLessonCommand must not be null");
        }

        _lessonRepository.CreateLesson(command.Lesson);
    }

    public void Handle(UpdateLessonCommand command)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"UpdateLessonCommand must not be null");
        }
        _lessonRepository.UpdateLesson(command.Lesson);
    }

    public void Handle(DeleteLessonCommand command)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"DeleteLessonCommand must not be null");
        }
        _lessonRepository.DeleteLesson(command.LessonId);
    }
}
using MediatR;
using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

/// <summary>
/// Handles command operations for lessons, including creation, update, and deletion.
/// It interacts with the lesson repository to persist changes.
/// </summary>
public class LessonCommandHandler : 
        IRequestHandler<CreateLessonCommand>, 
        IRequestHandler<UpdateLessonCommand>,
        IRequestHandler<DeleteLessonCommand>
        {
    private readonly ILessonRepository _lessonRepository;

    /// <summary>
    /// Initializes a new instance of the LessonCommandHandler class.
    /// </summary>
    /// <param name="lessonRepository">The repository used for lesson data operations.</param>
    public LessonCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository ?? throw new ArgumentNullException(nameof(lessonRepository));
    }

    /// <summary>
    /// Handles the creation of a lesson.
    /// </summary>
    /// <param name="command">The command containing the lesson to be created.</param>
    public async Task Handle(CreateLessonCommand command, CancellationToken cancellationToken)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"CreateLessonCommand must not be null");
        }

        await _lessonRepository.CreateLessonAsync(command.Lesson, cancellationToken);
    }

    /// <summary>
    /// Handles the update of a lesson.
    /// </summary>
    /// <param name="command">The command containing the lesson to be updated.</param>
    public async Task Handle(UpdateLessonCommand command, CancellationToken cancellationToken)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"UpdateLessonCommand must not be null");
        }
        await _lessonRepository.UpdateLessonAsync(command.Lesson, cancellationToken);
    }

    /// <summary>
    /// Handles the deletion of a lesson.
    /// </summary>
    /// <param name="command">The command containing the ID of the lesson to be deleted.</param>
    public async Task Handle(DeleteLessonCommand command, CancellationToken cancellationToken)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"DeleteLessonCommand must not be null");
        }
        await _lessonRepository.DeleteLessonAsync(command.LessonId, cancellationToken);
    }
}

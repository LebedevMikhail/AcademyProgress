using MediatR;

namespace ProgressAcademy.Application.Commands.Lesson
{
    /// <summary>
    /// Command for deleting a lesson.
    /// </summary>
    public class DeleteLessonCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the lesson to be deleted.
        /// </summary>
        public int LessonId { get; set; }
    }
}
using MediatR;

namespace ProgressAcademy.Application.Commands.Lesson
{
    /// <summary>
    /// Command for updating a lesson.
    /// </summary>
    public class UpdateLessonCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the lesson model with updated information.
        /// </summary>
        public Domain.Models.Lesson? Lesson { get; set; }
    }
}
using MediatR;

namespace ProgressAcademy.Application.Commands.Lesson
{
    /// <summary>
    /// Command for creating a new lesson.
    /// </summary>
    public class CreateLessonCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the lesson model that will be created.
        /// </summary>
        public Domain.Models.Lesson? Lesson { get; set; }
    }
}

using MediatR;

namespace ProgressAcademy.Application.Commands.Mentor
{
    /// <summary>
    /// Command for creating a new mentor.
    /// </summary>
    public class CreateMentorCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the mentor model that will be created.
        /// </summary>
        public Domain.Models.Mentor? Mentor { get; set; }
    }
}
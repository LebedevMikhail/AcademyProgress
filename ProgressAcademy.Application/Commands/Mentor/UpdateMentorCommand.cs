using MediatR;

namespace ProgressAcademy.Application.Commands.Mentor
{
    /// <summary>
    /// Command for updating a mentor.
    /// </summary>
    public class UpdateMentorCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the mentor model with updated information.
        /// </summary>
        public Domain.Models.Mentor? Mentor { get; set; }
    }
}
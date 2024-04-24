using MediatR;

namespace ProgressAcademy.Application.Commands.Mentee
{
    /// <summary>
    /// Command for updating a mentee.
    /// </summary>
    public class UpdateMenteeCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the mentee model with updated information.
        /// </summary>
        public Domain.Models.Mentee? Mentee { get; set; }
    }
}
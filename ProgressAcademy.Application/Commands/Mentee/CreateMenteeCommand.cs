using MediatR;

namespace ProgressAcademy.Application.Commands.Mentee
{
    /// <summary>
    /// Command for creating a new mentee.
    /// </summary>
    public class CreateMenteeCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the mentee model that will be created.
        /// </summary>
        public Domain.Models.Mentee? Mentee { get; set; }
    }
}

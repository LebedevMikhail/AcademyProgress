using MediatR;

namespace ProgressAcademy.Application.Commands.Mentee
{
    /// <summary>
    /// Command for deleting a mentee.
    /// </summary>
    public class DeleteMenteeCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the mentee to be deleted.
        /// </summary>
        public int MenteeId { get; set; }
    }
}
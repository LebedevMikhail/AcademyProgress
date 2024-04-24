using MediatR;

namespace ProgressAcademy.Application.Commands.Mentor
{
    /// <summary>
    /// Command for deleting a mentor.
    /// </summary>
    public class DeleteMentorCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the mentor to be deleted.
        /// </summary>
        public int MentorId { get; set; }
    }
}
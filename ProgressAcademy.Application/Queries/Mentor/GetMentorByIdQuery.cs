using MediatR;

namespace ProgressAcademy.Application.Queries.Mentor;

/// <summary>
/// Represents a query used to retrieve a mentor by their unique identifier.
/// </summary>
public class GetMentorByIdQuery : IRequest<Domain.Models.Mentor>
{
    /// <summary>
    /// Gets or sets the unique identifier of the mentor to retrieve.
    /// </summary>
    public int MentorId { get; set; }
}

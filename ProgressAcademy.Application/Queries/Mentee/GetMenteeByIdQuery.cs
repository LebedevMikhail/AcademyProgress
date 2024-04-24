using MediatR;

namespace ProgressAcademy.Application.Queries.Mentee;

/// <summary>
/// Represents a query used to retrieve a mentee by their unique identifier.
/// </summary>
public class GetMenteeByIdQuery: IRequest<Domain.Models.Mentee>
{
    /// <summary>
    /// Gets or sets the unique identifier of the mentee to retrieve.
    /// </summary>
    public int MenteeId { get; set; }
}

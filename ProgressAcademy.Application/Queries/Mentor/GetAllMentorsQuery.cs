using MediatR;

namespace ProgressAcademy.Application.Queries.Mentor;

/// <summary>
/// Represents a query used to retrieve all mentors.
/// </summary>
public class GetAllMentorsQuery : IRequest<IEnumerable<Domain.Models.Mentor>>
{
}

using MediatR;

namespace ProgressAcademy.Application.Queries.Mentee;

/// <summary>
/// Represents a query used to retrieve all mentees.
/// </summary>
public class GetAllMenteesQuery : IRequest<IEnumerable<Domain.Models.Mentee>>
{
}

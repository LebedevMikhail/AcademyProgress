using MediatR;

namespace ProgressAcademy.Application.Queries;

/// <summary>
/// Represents a query used to retrieve all plans.
/// </summary>
public class GetAllPlansQuery : IRequest<IEnumerable<Domain.Models.Plan>>
{
}

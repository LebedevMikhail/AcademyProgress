using MediatR;

namespace ProgressAcademy.Application.Queries.Plan;

/// <summary>
/// Represents a query used to retrieve a plan by its unique identifier.
/// </summary>
public class GetPlanByIdQuery : IRequest<Domain.Models.Plan>
{
    /// <summary>
    /// Gets or sets the unique identifier of the plan to retrieve.
    /// </summary>
    public int PlanId { get; set; }
}

using MediatR;
using ProgressAcademy.Application.Queries;
using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

/// <summary>
/// Handles queries related to 'Plan' entities by fetching data from the plan repository.
/// </summary>
public class PlanQueryHandler : 
             IRequestHandler<GetAllPlansQuery, IEnumerable<Plan>>, 
             IRequestHandler<GetPlanByIdQuery, Plan>
{
    private readonly IPlanRepository _planRepository;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanQueryHandler"/> class.
    /// </summary>
    /// <param name="planRepository">The repository for accessing plan data.</param>
    public PlanQueryHandler(IPlanRepository planRepository)
    {
        _planRepository = planRepository ?? throw new ArgumentNullException();
    }

    /// <summary>
    /// Retrieves a plan by its unique identifier.
    /// </summary>
    /// <param name="query">The query containing the ID of the plan to retrieve.</param>
    /// <returns>The <see cref="Plan"/> object if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null or the PlanId is zero.</exception>
    public async Task<Plan> Handle(GetPlanByIdQuery query, CancellationToken cancellationToken)
    {
        if(query == null || query.PlanId == 0)
        {
            throw new ArgumentNullException("GetPlanByIdQuery must not be null or the PlanId value is zero.");
        }
        return await _planRepository.GetPlanByIdAsync(query.PlanId, cancellationToken);
    }

    /// <summary>
    /// Retrieves all plans.
    /// </summary>
    /// <param name="query">The query to retrieve all plans.</param>
    /// <returns>An enumerable collection of <see cref="Plan"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query, CancellationToken cancellationToken)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        if(query == null)
        {
            throw new ArgumentNullException("GetAllPlansQuery must not be null.");
        }
        return await _planRepository.GetAllPlansAsync(cancellationTokenSource.Token);
    }
}

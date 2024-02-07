using ProgressAcademy.Application.Queries;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

public class PlanQueryHandler
{
    private readonly IPlanRepository _planRepository;
    
    public PlanQueryHandler(
        IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public Plan Handle(GetPlanByIdQuery query)
    {
        if(query == null || query.PlanId == 0)
        {
            throw new ArgumentNullException($"GetPlanByIdQuery must not be null or the PlanId value is zero ");
        }
        return  _planRepository.GetPlanById(query.PlanId);
    }

    public IEnumerable<Plan?> Handle(GetAllPlansQuery query)
    {
        if(query == null )
        {
            throw new ArgumentNullException($"GetAllPlansQuery must not be null");
        }
        return _planRepository.GetAllPlans();
    }
}
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
        var res =  _planRepository.GetPlanById(query.PlanId);
        return res;
    }

    public IEnumerable<Plan?> Handle(GetAllPlansQuery query)
    {
        return _planRepository.GetAllPlans();
    }
}
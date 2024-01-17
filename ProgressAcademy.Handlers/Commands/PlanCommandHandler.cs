using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

public class PlanCommandHandler
{
    private readonly IPlanRepository _planRepository;

    public PlanCommandHandler(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public void Handle(CreatePlanCommand command)
    {
        _planRepository.CreatePlan(command.Plan);
    }

    public void Handle(UpdatePlanCommand command)
    {
        _planRepository.UpdatePlan(command.Plan);
    }

    public void Handle(DeletePlanCommand command)
    {
        _planRepository.DeletePlan(command.PlanId);
    }
}
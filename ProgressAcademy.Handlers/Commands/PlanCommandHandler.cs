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
        if(command?.Plan == null)
        {
            throw new ArgumentNullException($"CreatePlanCommand must not be null");
        }

        _planRepository.CreatePlan(command.Plan);
    }

    public void Handle(UpdatePlanCommand command)
    {
        if(command?.Plan == null)
        {
            throw new ArgumentNullException($"UpdatePlanCommand must not be null");
        }

        _planRepository.UpdatePlan(command.Plan);
    }

    public void Handle(DeletePlanCommand command)
    {
        if(command == null || command.PlanId == 0 )
        {
            throw new ArgumentNullException($"DeletePlanCommand must not be null or PlanId must not be zero");
        }

        _planRepository.DeletePlan(command.PlanId);
    }
}
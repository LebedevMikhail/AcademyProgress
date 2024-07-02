using System.Runtime.CompilerServices;
using MediatR;
using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

/// <summary>
/// Handles command operations for "Plan" entities, such as creation, update, and deletion.
/// </summary>
public class PlanCommandHandler :
        IRequestHandler<CreatePlanCommand>,
        IRequestHandler<UpdatePlanCommand>,
        IRequestHandler<DeletePlanCommand>
{
    private readonly IPlanRepository _planRepository;

    /// <summary>
    /// Initializes a new instance of the PlanCommandHandler with an IPlanRepository.
    /// </summary>
    /// <param name="planRepository">The repository responsible for executing operations related to "Plan" entities.</param>
    public PlanCommandHandler(IPlanRepository planRepository)
    {
        _planRepository = planRepository ?? throw new ArgumentNullException(nameof(planRepository));
    }

    /// <summary>
    /// Handles the creation of a new "Plan".
    /// Validates the command input before proceeding with the creation operation.
    /// </summary>
    /// <param name="command">The command containing the "Plan" data to be created.</param>
    public async Task Handle(CreatePlanCommand command, CancellationToken cancellationToken)
    {
        if (command?.Plan == null)
        {
            throw new ArgumentNullException($"CreatePlanCommand must not be null");
        }

        await _planRepository.CreatePlanAsync(command.Plan, cancellationToken);
    }

    /// <summary>
    /// Handles the updating of an existing "Plan".
    /// Ensures the command input is valid before applying the update.
    /// </summary>
    /// <param name="command">The command containing the updated "Plan" data.</param>
    public async Task Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        if (command?.Plan == null)
        {
            throw new ArgumentNullException($"UpdatePlanCommand must not be null");
        }

        await _planRepository.UpdatePlanAsync(command.Plan, cancellationToken);
    }

    /// <summary>
    /// Handles the deletion of a "Plan" based on its unique identifier.
    /// Validates that the command and PlanId are valid before proceeding with the deletion.
    /// </summary>
    /// <param name="command">The command indicating which "Plan" to delete.</param>
    public async Task Handle(DeletePlanCommand command, CancellationToken cancellationToken)
    {
        if (command == null || command.PlanId == 0)
        {
            throw new ArgumentNullException($"DeletePlanCommand must not be null or PlanId must not be zero");
        }

        await _planRepository.DeletePlanAsync(command.PlanId, cancellationToken);
    }
}
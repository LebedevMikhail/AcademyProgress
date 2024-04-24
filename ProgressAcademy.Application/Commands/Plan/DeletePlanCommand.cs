using MediatR;

namespace ProgressAcademy.Application.Commands.Plan
{
    /// <summary>
    /// Command for deleting a plan.
    /// </summary>
    public class DeletePlanCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the plan to be deleted.
        /// </summary>
        public int PlanId { get; set; }
    }
}
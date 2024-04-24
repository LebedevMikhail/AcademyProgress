using MediatR;

namespace ProgressAcademy.Application.Commands.Plan
{
    /// <summary>
    /// Command for updating a plan.
    /// </summary>
    public class UpdatePlanCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the plan model with updated information.
        /// </summary>
        public Domain.Models.Plan? Plan { get; set; }
    }
}

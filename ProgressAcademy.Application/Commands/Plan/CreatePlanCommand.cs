using MediatR;

namespace ProgressAcademy.Application.Commands.Plan
{
    /// <summary>
    /// Command for creating a new plan.
    /// </summary>
    public class CreatePlanCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the plan model that will be created.
        /// </summary>
        public Domain.Models.Plan? Plan { get; set; }
    }
}
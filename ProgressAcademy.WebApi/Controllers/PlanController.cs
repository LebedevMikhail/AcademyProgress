using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProgressAcademy.Application.Queries;

namespace ProgressAcademy.WebApi.Controllers;

/// <summary>
/// The PlanController class is responsible for handling HTTP requests related to educational plans,
/// including operations such as retrieving, creating, updating, and deleting plans.
/// It leverages the MediatR library to delegate command and query operations to their respective handlers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the PlanController with a specified IMediator instance for command and query dispatch.
    /// </summary>
    /// <param name="mediator">The MediatR IMediator instance used for handling operations.</param>
    public PlanController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Retrieves all educational plans available.
    /// </summary>
    /// <returns>An action result containing a list of all plans.</returns>
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<Plan>), 200)]
    public async Task<IActionResult> GetAllPlans()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetAllPlansQuery();
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a specific educational plan by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the plan to retrieve.</param>
    /// <returns>An action result containing the specified plan.</returns>
    [HttpGet("GetById")]
    [ProducesResponseType(typeof(Plan), 200)]
    public async Task<IActionResult> GetPlanById(int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetPlanByIdQuery()
        {
            PlanId = id
        };
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new educational plan with the provided details.
    /// </summary>
    /// <param name="plan">The plan entity to create.</param>
    /// <returns>An action result indicating the outcome of the create operation.</returns>
    [HttpPost("Create")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> CreatePlan([FromBody] Plan plan)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new CreatePlanCommand()
        {
            Plan = plan
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Updates an existing educational plan with the provided details.
    /// </summary>
    /// <param name="plan">The updated plan entity.</param>
    /// <returns>An action result indicating the outcome of the update operation.</returns>
    [HttpPut("Update")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdatePlan([FromBody] Plan plan)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new UpdatePlanCommand()
        {
            Plan = plan
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Deletes an educational plan based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the plan to delete.</param>
    /// <returns>An action result indicating the outcome of the delete operation.</returns>
    [HttpDelete("Delete")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeletePlan([FromBody] int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new DeletePlanCommand()
        {
            PlanId = id
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }
}
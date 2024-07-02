using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ProgressAcademy.WebApi.Controllers;

/// <summary>
/// The MentorController class handles HTTP requests related to mentor operations, 
/// including retrieving, creating, updating, and deleting mentors.
/// It utilizes the MediatR library to delegate the execution of these operations to the appropriate handlers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MentorController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructs a new instance of the MentorController with a specified IMediator instance.
    /// </summary>
    /// <param name="mediator">The MediatR IMediator instance used for dispatching commands and queries.</param>
    public MentorController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Retrieves a list of all mentors.
    /// </summary>
    /// <returns>A list of mentor entities.</returns>
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<Mentor>), 200)]
    public async Task<IActionResult> GetAllMentors()
    {
        var query = new GetAllMentorsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a specific mentor by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the mentor to retrieve.</param>
    /// <returns>The mentor entity associated with the specified ID.</returns>
    [HttpGet("GetById")]
    [ProducesResponseType(typeof(Mentor), 200)]

    public async Task<IActionResult> GetMentorById(int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetMentorByIdQuery()
        {
            MentorId = id
        };
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new mentor with the provided mentor details.
    /// </summary>
    /// <param name="mentor">The mentor entity to create.</param>
    /// <returns>A status indicating the outcome of the create operation.</returns>
    [HttpPost("Create")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> CreateMentor([FromBody] Mentor mentor)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new CreateMentorCommand()
        {
            Mentor = mentor
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Updates an existing mentor with the provided details.
    /// </summary>
    /// <param name="mentor">The updated mentor entity.</param>
    /// <returns>A status indicating the outcome of the update operation.</returns>
    [HttpPut("Update")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdateMentor([FromBody] Mentor mentor)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new UpdateMentorCommand()
        {
            Mentor = mentor
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Deletes a mentor by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the mentor to delete.</param>
    /// <returns>A status indicating the outcome of the delete operation.</returns>
    [HttpDelete("Delete")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeleteMentor([FromBody] int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new DeleteMentorCommand()
        {
            MentorId = id
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }
}
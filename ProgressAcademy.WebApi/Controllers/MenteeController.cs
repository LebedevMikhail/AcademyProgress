using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgressAcademy.Application.Commands.Mentee;
using ProgressAcademy.Application.Queries.Mentee;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.WebApi.Controllers;

/// <summary>
/// The MenteeController handles HTTP requests related to Mentee operations.
/// It uses the MediatR library to send queries and commands for processing.
/// </summary>
[ApiController]
[Route("[controller]")]
public class MenteeController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the MenteeController.
    /// </summary>
    /// <param name="mediator">An instance of IMediator for sending requests.</param>
    public MenteeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves a mentee by their ID.
    /// </summary>
    /// <param name="id">The ID of the mentee to retrieve.</param>
    /// <returns>An ActionResult containing the retrieved Mentee.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<Mentee>> GetMentee(int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetMenteeByIdQuery { MenteeId = id };
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all mentees.
    /// </summary>
    /// <returns>An ActionResult containing a list of all Mentees.</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<Mentee>> GetMentees()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetAllMenteesQuery();
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new mentee.
    /// </summary>
    /// <param name="mentee">The Mentee object to create.</param>
    /// <returns>An ActionResult containing the created Mentee.</returns>
    [HttpPost]
    [ProducesResponseType(200)]

    public async Task<ActionResult<Mentee>> CreateMentee(Mentee mentee)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new CreateMenteeCommand { Mentee = mentee };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Deletes a mentee by their ID.
    /// </summary>
    /// <param name="id">The ID of the mentee to delete.</param>
    /// <returns>An ActionResult indicating the result of the delete operation.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]

    public async Task<ActionResult<Mentee>> DeleteMentee(int id)
    {
        var cancellationToken = new CancellationTokenSource();
        var command = new DeleteMenteeCommand { MenteeId = id };
        await _mediator.Send(command, cancellationToken.Token);
        return Ok();
    }

    /// <summary>
    /// Updates a mentee.
    /// </summary>
    /// <param name="mentee">The updated Mentee object.</param>
    /// <returns>An ActionResult containing the updated Mentee.</returns>
    [HttpPut]
    [ProducesResponseType(200)]
    public async Task<ActionResult<Mentee>> UpdateMentee(Mentee mentee)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new UpdateMenteeCommand { Mentee = mentee };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }
}
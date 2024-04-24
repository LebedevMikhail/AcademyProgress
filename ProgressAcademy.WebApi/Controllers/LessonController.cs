using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ProgressAcademy.WebApi.Controllers;

/// <summary>
/// The LessonController class handles HTTP requests related to lesson operations, 
/// including retrieving, creating, updating, and deleting lessons.
/// It leverages the MediatR library to delegate the handling of these operations to respective handlers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the LessonController with the specified IMediator instance.
    /// </summary>
    /// <param name="mediator">The MediatR IMediator instance used for sending commands and queries.</param>
    public LessonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all lessons.
    /// </summary>
    /// <returns>A list of all lessons.</returns>
    [HttpGet("GetAllLessons")]
    [ProducesResponseType(typeof(IEnumerable<Lesson>), 200)]
    public async Task<IActionResult> GetAllLessons()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetAllLessonsQuery();
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a specific lesson by its ID.
    /// </summary>
    /// <param name="id">The ID of the lesson to retrieve.</param>
    /// <returns>The lesson with the specified ID.</returns>
    [HttpGet("GetLessonById")]
    [ProducesResponseType(typeof(Lesson), 200)]
    public async Task<IActionResult> GetLessonById(int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var query = new GetLessonByIdQuery()
        {
            LessonId = id
        };
        var result = await _mediator.Send(query, cancellationTokenSource.Token);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new lesson with the provided lesson details.
    /// </summary>
    /// <param name="lesson">The lesson object containing the details of the lesson to create.</param>
    /// <returns>A status indicating the result of the create operation.</returns>
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<IActionResult> CreateLesson([FromBody] Lesson lesson)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new CreateLessonCommand()
        {
            Lesson = lesson
        };
      await  _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Updates an existing lesson with the provided lesson details.
    /// </summary>
    /// <param name="lesson">The updated lesson object.</param>
    /// <returns>A status indicating the result of the update operation.</returns>
    [HttpPut]
    [ProducesResponseType(200)]
    public async Task< IActionResult> UpdateLesson([FromBody] Lesson lesson)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new UpdateLessonCommand()
        {
            Lesson = lesson
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }

    /// <summary>
    /// Deletes a lesson by its ID.
    /// </summary>
    /// <param name="id">The ID of the lesson to delete.</param>
    /// <returns>A status indicating the result of the delete operation.</returns>
    [HttpDelete]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeleteLesson([FromBody] int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var command = new DeleteLessonCommand()
        {
            LessonId = id
        };
        await _mediator.Send(command, cancellationTokenSource.Token);
        return Ok();
    }
}
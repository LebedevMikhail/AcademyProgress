using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Application.Queries;
using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Handlers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ProgressAcademy.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
   private readonly LessonQueryHandler _lessonQueryHandler;
   private readonly LessonCommandHandler _lessonCommandHandler;
   
   public LessonController(LessonQueryHandler lessonQueryHandler, LessonCommandHandler lessonCommandHandler)
    {
        _lessonQueryHandler = lessonQueryHandler;
        _lessonCommandHandler = lessonCommandHandler;
    }

    [HttpGet("GetAllLessons")]
    public IActionResult GetAllLessons()
    {
        var query = new GetAllLessonsQuery();
        var result = _lessonQueryHandler.Handle(query);
        return Ok(result);
    }
    
    [HttpGet("GetLessonById")]
    public IActionResult GetLessonById(int id)
    {
        var query = new GetLessonByIdQuery()
        {
            LessonId = id
        };
        var result = _lessonQueryHandler.Handle(query);
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult CreateLesson([FromBody]Lesson lesson)
    {
        var command = new CreateLessonCommand()
        {
            Lesson = lesson
        };
        _lessonCommandHandler.Handle(command);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdateLesson([FromBody]Lesson lesson)
    {
        var command = new UpdateLessonCommand()
        {
            Lesson = lesson
        };
        _lessonCommandHandler.Handle(command);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteLesson([FromBody] int id)
    {
        var command = new DeleteLessonCommand()
        {
            LessonId = id
        };
        _lessonCommandHandler.Handle(command);
        return Ok();
    }
}
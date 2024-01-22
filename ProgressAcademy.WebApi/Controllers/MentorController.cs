using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Handlers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ProgressAcademy.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController : ControllerBase
{
   private readonly MentorQueryHandler _mentorQueryHandler;
   private readonly MentorCommandHandler _mentorCommandHandler;
   
   public MentorController(MentorQueryHandler mentorQueryHandler, MentorCommandHandler mentorCommandHandler)
    {
        _mentorQueryHandler = mentorQueryHandler;
        _mentorCommandHandler = mentorCommandHandler;
    }

    [HttpGet("GetAllMentors")]
    public IActionResult GetAllMentors()
    {
        var query = new GetAllMentorsQuery();
        var result = _mentorQueryHandler.Handle(query);
        return Ok(result);
    }
    
    [HttpGet("GetMentorById")]
    public IActionResult GetMentorById(int id)
    {
        var query = new GetMentorByIdQuery()
        {
            MentorId = id
        };
        var result = _mentorQueryHandler.Handle(query);
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult CreateMentor([FromBody]Mentor mentor)
    {
        var command = new CreateMentorCommand()
        {
            Mentor = mentor
        };
        _mentorCommandHandler.Handle(command);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdateMentor([FromBody]Mentor mentor)
    {
        var command = new UpdateMentorCommand()
        {
            Mentor = mentor
        };
        _mentorCommandHandler.Handle(command);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteMentor([FromBody] int id)
    {
        var command = new DeleteMentorCommand()
        {
            MentorId = id
        };
        _mentorCommandHandler.Handle(command);
        return Ok();
    }
}
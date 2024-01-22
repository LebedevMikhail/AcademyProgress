using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Application.Queries;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Handlers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ProgressAcademy.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanController : ControllerBase
{
   private readonly PlanQueryHandler _planQueryHandler;
   private readonly PlanCommandHandler _planCommandHandler;
   
   public PlanController(PlanQueryHandler planQueryHandler, PlanCommandHandler planCommandHandler)
    {
        _planQueryHandler = planQueryHandler;
        _planCommandHandler = planCommandHandler;
    }

    [HttpGet("GetAllPlans")]
    public IActionResult GetAllPlans()
    {
        var query = new GetAllPlansQuery();
        var result = _planQueryHandler.Handle(query);
        return Ok(result);
    }
    
    [HttpGet("GetPlanById")]
    public IActionResult GetPlanById(int id)
    {
        var query = new GetPlanByIdQuery()
        {
            PlanId = id
        };
        var result = _planQueryHandler.Handle(query);
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult CreatePlan([FromBody]Plan plan)
    {
        var command = new CreatePlanCommand()
        {
            Plan = plan
        };
        _planCommandHandler.Handle(command);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdatePlan([FromBody]Plan plan)
    {
        var command = new UpdatePlanCommand()
        {
            Plan = plan
        };
        _planCommandHandler.Handle(command);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeletePlan([FromBody] int id)
    {
        var command = new DeletePlanCommand()
        {
            PlanId = id
        };
        _planCommandHandler.Handle(command);
        return Ok();
    }
}
using Microsoft.AspNetCore.Mvc;
using SimpleVote.Services;
using SimpleVote.Models;

namespace SimpleVote.Controllers;

[ApiController]
[Route("api/v1")]
public class VotingController : ControllerBase
{
    private readonly VotingService _votingService;

    public VotingController(VotingService votingService)
    {
        _votingService = votingService;
    }

    [HttpGet("candidate-items")]
    public ActionResult<List<Item>> GetCandidateItems()
    {
        return Ok(_votingService.Items);
    }

    [HttpPost("vote/id")]
    public ActionResult Vote(int id)
    {
        var accessIp = HttpContext.Connection.RemoteIpAddress?.ToString();
        if (accessIp is null)
        {
            return BadRequest(new 
            { 
                message = "Cannot identify IP Address of the request." 
            });
        }

        var success = _votingService.Vote(id, accessIp);
        
        if (!success)
        {
            return BadRequest(new 
            { 
                message = "Failed to vote." 
            });
        }

        return Ok();
    }
}
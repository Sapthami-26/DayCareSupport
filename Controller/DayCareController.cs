using DayCareSupportAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DayCareController : ControllerBase
{
    private readonly DayCareRepository _repo;

    public DayCareController(DayCareRepository repo)
    {
        _repo = repo;
    }

    // Insert or Update child data
    [HttpPost("add-or-update")]
    public IActionResult AddOrUpdateChild([FromBody] ChildData child)
    {
        var result = _repo.AddOrUpdateChild(child);
        if (result > 0) return Ok(new { Success = true });
        return BadRequest(new { Success = false });
    }

    // Delete child record
    [HttpDelete("{rid}/{dcid}")]
    public IActionResult DeleteChild(int rid, int dcid)
    {
        var deleted = _repo.DeleteChild(rid, dcid);
        if (deleted > 0) return Ok(new { Deleted = true });
        return NotFound(new { Deleted = false });
    }

    // Final submission (choice=1 employee, 3 HR)
    [HttpPost("submit/{rid}/{dcid}/{choice}")]
    public IActionResult Submit(int rid, int dcid, int choice)
    {
        var submitted = _repo.SubmitDraftStatus(rid, dcid, choice);
        if (submitted > 0) return Ok(new { Submitted = true });
        return BadRequest(new { Submitted = false });
    }

    // Get quarter for date range
    [HttpGet("quarter")]
    public IActionResult GetQuarter([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var quarter = _repo.GetQuarter(startDate, endDate);
        return Ok(new { Quarter = quarter });
    }
}

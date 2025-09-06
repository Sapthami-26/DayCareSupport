using DayCareApi.Models;
using DayCareApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DayCareApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayCareController : ControllerBase
    {
        private readonly IDayCareRepository _repo;

        public DayCareController(IDayCareRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("quarter")]
        public ActionResult<int> GetQuarter(DateTime start, DateTime end)
        {
            return _repo.GetQuarter(start, end);
        }

        [HttpPost("child")]
        public IActionResult AddChild([FromBody] ChildData child)
        {
            var result = _repo.AddOrUpdateChild(child, 1); // 1 for add
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("child")]
        public IActionResult UpdateChild([FromBody] ChildData child)
        {
            var result = _repo.AddOrUpdateChild(child, 2); // 2 for update
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete("child/{rid}/{dcid}")]
        public IActionResult DeleteChild(int rid, int dcid)
        {
            var result = _repo.DeleteChild(rid, dcid);
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPost("child/finalize")]
        public IActionResult FinalizeChild([FromBody] ChildData child)
        {
            var result = _repo.UpdateDraftStatus(child.RID, child.DCID, 1); // Choice: 1 for submit, 3 for HR approve
            return result > 0 ? Ok() : BadRequest();
        }
    }
}

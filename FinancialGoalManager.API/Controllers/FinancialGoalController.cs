using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterGoal()
        {

            // return BadRequest();

            return Created("", true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal()
        {

            // return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGoal()
        {

            // return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListGoals()
        {


            return Ok();
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetGoalsDetails()
        {


            return Ok();
        }
    }
}

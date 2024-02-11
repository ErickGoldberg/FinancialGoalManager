using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FinancialGoalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterGoal()
        {

            // return BadRequest();

            return Created("", true);
        }

        [HttpPost]
        public async Task<IActionResult> UploadCover()
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

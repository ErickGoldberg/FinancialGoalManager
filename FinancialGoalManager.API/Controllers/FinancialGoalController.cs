using FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal;
using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FinancialGoalManager.Application.Commands.FinancialGoals.SimulateFinancialEvolution;
using FinancialGoalManager.Application.Commands.FinancialGoals.UpdateGoal;
using FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover;
using FinancialGoalManager.Application.Queries.FinancialGoalQueries.GetGoalsDetails;
using FinancialGoalManager.Application.Queries.FinancialGoalQueries.ListGoals;
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
        public async Task<IActionResult> RegisterGoal(RegisterGoalCommand command)
        {
            await _mediator.Send(command);

            return Created("Your Goal was registered successfully!", true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal(UpdateGoalCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                BadRequest("Id do not exist!");

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGoal(DeleteGoalCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                BadRequest("Id do not exist!");

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListGoals()
        {
            var query = new ListGoalsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetGoalsDetails()
        {
            var query = new GetGoalsDetailsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("SimulateEvolution")]
        public async Task<IActionResult> SimulateFinancialEvolution(SimulateFinancialEvolutionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("UploadCover")]
        public async Task<IActionResult> UploadCover(UploadCoverCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                BadRequest("Id do not exist!");

            return Created("The Cover was uploaded successfully!", true);
        }
    }
}
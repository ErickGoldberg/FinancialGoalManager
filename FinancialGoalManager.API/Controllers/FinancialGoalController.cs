using FinancialGoalManager.Application.Abstractions;
using FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal;
using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FinancialGoalManager.Application.Commands.FinancialGoals.SimulateFinancialEvolution;
using FinancialGoalManager.Application.Commands.FinancialGoals.UpdateGoal;
using FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover;
using FinancialGoalManager.Application.Queries.FinancialGoalQueries.GetGoalsDetails;
using FinancialGoalManager.Application.Queries.FinancialGoalQueries.ListGoals;
using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FinancialGoalController(IMediator mediator) => _mediator = mediator;
        
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
                return NotFound(Result<object>.Failure());

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var command = new DeleteGoalCommand(id);

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(Result<object>.Failure());

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListGoals()
        {
            var query = new ListGoalsQuery();

            var result = await _mediator.Send(query);

            return Ok(Result<List<FinancialGoalDto>>.Success(result));
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetGoalsDetails()
        {
            var query = new GetGoalsDetailsQuery();

            var result = await _mediator.Send(query);

            return Ok(Result<List<FinancialGoal>>.Success(result));
        }

        [HttpPost]
        [Route("SimulateEvolution")]
        public async Task<IActionResult> SimulateFinancialEvolution(SimulateFinancialEvolutionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(Result<string>.Success(result));
        }

        [HttpPost]
        [Route("UploadCover")]
        public async Task<IActionResult> UploadCover(UploadCoverCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(Result<object>.Failure());

            return Created("The Cover was uploaded successfully!", true);
        }
    }
}
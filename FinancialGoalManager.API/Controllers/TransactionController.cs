using FinancialGoalManager.Application.Commands.Transaction.RemoveTransaction;
using FinancialGoalManager.Application.Commands.Transaction.SendTransaction;
using FinancialGoalManager.Application.Queries.Transaction.ListTransactions;
using FinancialGoalManager.Application.Queries.Transaction.GetTransactionsDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator) => _mediator = mediator;
        
        [HttpPost]
        public async Task<IActionResult> SendTransaction(SendTransactionCommand command)
        {
            await _mediator.Send(command);

            return Created("Your transaction was made successfully!", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTransaction(int id)
        {
            var command = new RemoveTransactionCommand(id);

            var result = await _mediator.Send(command);

            if (!result)
                BadRequest("An error has occured!");

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListTransactions()
        {
            var query = new ListTransactionsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetTransactionsDetails()
        {
            var query = new GetTransactionsDetailsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
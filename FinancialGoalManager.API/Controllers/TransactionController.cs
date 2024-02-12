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
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendTransaction(SendTransactionCommand command)
        {
            await _mediator.Send(command);

            return Created("Your transaction was made successfully!", true);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTransaction(RemoveTransactionCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListTransactions()
        {
            var query = new ListTransactionsQuery();

            await _mediator.Send(query);

            return Ok();
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetTransactionsDetails()
        {
            var query = new GetTransactionsDetailsQuery();

            await _mediator.Send(query);

            return Ok();
        }
    }
}

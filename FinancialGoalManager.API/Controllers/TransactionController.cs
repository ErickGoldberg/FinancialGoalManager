﻿using FinancialGoalManager.Application.Commands.Transaction.RemoveTransaction;
using FinancialGoalManager.Application.Commands.Transaction.SendTransaction;
using FinancialGoalManager.Application.Queries.Transaction.ListTransactions;
using FinancialGoalManager.Application.Queries.Transaction.GetTransactionsDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinancialGoalManager.Application.Abstractions;
using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;

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
            var isSuccess = await _mediator.Send(command);

            if(!isSuccess)
                return NotFound(Result<SendTransactionCommand>.NotFound());

            return Created(string.Empty, "Your transaction was made successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTransaction(int id)
        {
            var command = new RemoveTransactionCommand(id);

            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(Result<RemoveTransactionCommand>.Failure());

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListTransactions()
        {
            var query = new ListTransactionsQuery();

            var result = await _mediator.Send(query);

            return Ok(Result<List<TransactionDto>>.Success(result));
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetTransactionsDetails()
        {
            var query = new GetTransactionsDetailsQuery();

            var result = await _mediator.Send(query);

            return Ok(Result<List<Transaction>>.Success(result));
        }
    }
}
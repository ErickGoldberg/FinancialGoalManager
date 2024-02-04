﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendTransaction()
        {

            return Created("", true);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTransaction()
        {

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListTransactions()
        {


            return Ok();
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetTransactionsDetails()
        {


            return Ok();
        }
    }
}

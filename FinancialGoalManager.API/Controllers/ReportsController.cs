using FinancialGoalManager.Application.Abstractions;
using FinancialGoalManager.Application.Queries.Reports.GetReports;
using FinancialGoalManager.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator) => _mediator = mediator;
        
        /// <summary>
        /// Generate a Report About the Amount Evolution.
        /// </summary>
        /// <returns>Report</returns>
        /// <response code="200">Returns a Reports About the Amount Evolution</response>
        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var query = new GetReportsQuery();

            var reports = await _mediator.Send(query);

            return Ok(Result<List<ReportsDto>>.Success(reports));
        }
    }
}
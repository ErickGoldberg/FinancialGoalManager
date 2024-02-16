using FinancialGoalManager.Application.Queries.Reports.GetReports;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(reports);
        }
    }
}
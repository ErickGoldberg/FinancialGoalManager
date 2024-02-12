using FinancialGoalManager.Application.Queries.Reports.GetReports;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var query = new GetReportsQuery();

            var reports = _mediator.Send(query);

            return Ok(reports);
        }
    }
}

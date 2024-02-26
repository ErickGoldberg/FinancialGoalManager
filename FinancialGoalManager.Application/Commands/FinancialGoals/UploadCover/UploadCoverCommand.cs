using MediatR;
using Microsoft.AspNetCore.Http;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover
{
    public class UploadCoverCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public required IFormFile Cover { get; set; }
    }
}
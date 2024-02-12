using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover
{
    public class UploadCoverCommand : IRequest
    {
        public int Id { get; set; }
        public byte[] Cover { get; set; }
    }
}

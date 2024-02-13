using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover
{
    public class UploadCoverCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public byte[] Cover { get; set; }
    }
}

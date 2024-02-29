using FinancialGoalManager.Core.Services;

namespace FinancialGoalManager.Infrastructure.Persistence.AWS
{
    public class SendToS3Service : ISendToS3Service
    {
        private readonly IMessagebusService _messageBusService;
        public SendToS3Service(IMessagebusService messageBusService) => _messageBusService = messageBusService;

        public void SendFileToS3(byte[] file, string fileName, int fileId)
        {
            throw new NotImplementedException();
        }
    }
}

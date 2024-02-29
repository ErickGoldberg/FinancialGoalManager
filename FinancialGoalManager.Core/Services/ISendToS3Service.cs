namespace FinancialGoalManager.Core.Services
{
    public interface ISendToS3Service
    {
         void SendFileToS3(byte[] file, string fileName, int fileId);
    }
}

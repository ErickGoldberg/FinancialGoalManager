using FinancialGoalManager.Infrastructure.Persistence;

namespace FinancialGoalManager.API.Jobs
{
    public class RememberDaysLeftJob : IHostedService
    {
        #region Props

        private Timer _timer;
        public IServiceProvider ServiceProvider { get; set; }

        #endregion

        public RememberDaysLeftJob(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(NotificateTransactionDaysLeft, null, 0, 86400000);
            return Task.CompletedTask;
        }

        public void NotificateTransactionDaysLeft(object? state)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope
                    .ServiceProvider
                    .GetRequiredService<FinancialGoalManagerDbContext>();

                var dataLimite = DateTime.Now.AddDays(15);

                var goalsWithCloseDeadline = context.FinancialGoals
                    .Where(goal => goal.Deadline <= dataLimite)
                    .Select(i => i.Title)
                    .ToList();

                var result = goalsWithCloseDeadline.Any()
                    ? $"These are the goal(s) that will expire in less than 15 days! Titles: {string.Join(", ", goalsWithCloseDeadline)}"
                    : "There are no goals set to be completed within the next 15 days!";

                Console.WriteLine(result);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
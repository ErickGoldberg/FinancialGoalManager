using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Application.Validators.Helper
{
    public static class ValidatorsHelper
    {
        public static bool ValidateTitle(string? title)
        {
            if (title != null && (title.Length > 30 || title.Length < 3))
                    return false;

            return true;
        }

        public static bool ValidateGoalAmount(decimal? goalAmount)
        {
            if (goalAmount != null && (goalAmount < 500 || goalAmount > 1000000 ))
                return false;

            return true;
        }

        public static bool ValidateDeadLine(DateTime? deadline)
        {
            if (deadline != null && (deadline < DateTime.Now.AddMonths(2) || deadline > DateTime.Now.AddYears(5)))
                return false;

            return true;
        }

        public static bool ValidateStatus(FinancialGoalStatusEnum? status)
        {
            if (status != null && !Enum.IsDefined(typeof(FinancialGoalStatusEnum), status))
                return false;

            return true;
        }
    }
}
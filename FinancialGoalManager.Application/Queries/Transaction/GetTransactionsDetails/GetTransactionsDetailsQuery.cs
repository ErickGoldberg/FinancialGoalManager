﻿using FinancialGoalManager.Core.Entities;
using MediatR;

namespace FinancialGoalManager.Application.Queries.Transaction.GetTransactionsDetails
{
    public class GetTransactionsDetailsQuery : IRequest<List<Transaction>>
    {
        // Ignore
    }
}

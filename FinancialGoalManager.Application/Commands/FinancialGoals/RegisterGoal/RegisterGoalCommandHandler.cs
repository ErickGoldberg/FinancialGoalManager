﻿using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal
{
    public class RegisterGoalCommandHandler : IRequestHandler<RegisterGoalCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterGoalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RegisterGoalCommand request, CancellationToken cancellationToken)
        {
            var command = new FinancialGoal(request.Title, request.GoalAmount, request.Status, request.Deadline);

            await _unitOfWork.FinancialGoalRepository.RegisterGoal(command);
            await _unitOfWork.CompleteAsync();
        }
    }
}
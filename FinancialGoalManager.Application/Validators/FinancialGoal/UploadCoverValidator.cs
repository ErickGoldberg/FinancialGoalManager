using FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FinancialGoalManager.Application.Validators.FinancialGoal
{
    public class UploadCoverValidator : AbstractValidator<UploadCoverCommand>
    {
        public UploadCoverValidator()
        {
            RuleFor(i => i.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id is mandatory!");

            RuleFor(i => i.Cover)
                .NotNull()
                .NotEmpty()
                .WithMessage("Cover is mandatory!")
                .Must(BeAValidFile)
                .WithMessage("Invalid file format or file is too large."); 
        }

        private bool BeAValidFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            if (file.Length > 10 * 1024 * 1024) // 10MB em bytes
                return false;

            var fileName = file.FileName;

            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            string fileExtension = Path.GetExtension(fileName).ToLowerInvariant();

            return allowedExtensions.Contains(fileExtension);
        }
    }
}
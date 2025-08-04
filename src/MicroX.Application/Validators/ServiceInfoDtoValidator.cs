using FluentValidation;
using MicroX.Contracts.DTOs;

namespace MicroX.Application.Validators
{
    public class ServiceInfoDtoValidator : AbstractValidator<ServiceInfoDto>
    {
        public ServiceInfoDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Service name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Version)
                .NotEmpty().WithMessage("Version is required.")
                .Matches(@"^\d+\.\d+\.\d+$").WithMessage("Version must be in format x.y.z");

            RuleFor(x => x.Status)
                .NotEmpty()
                .Must(status => new[] { "Healthy", "Degraded", "Unknown" }.Contains(status))
                .WithMessage("Status must be 'Healthy', 'Degraded', or 'Unknown'.");

            // RuleFor(x => x.Environment)
            //     .NotEmpty().WithMessage("Environment is required.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WLMT.Bungalows.Application.UseCases.Campaigns.Commands;


namespace WLMT.Bungalows.Application.UseCases.Campaigns.Validators
{
    public class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommand>
    {
        public CreateCampaignCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.Budget).GreaterThan(0).WithMessage("Budget must be positive");
        }
    }
}

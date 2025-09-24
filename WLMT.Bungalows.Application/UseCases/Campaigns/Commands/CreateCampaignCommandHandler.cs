using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WLMT.Bungalows.Domain.Entities;
using WLMT.Bungalows.Domain.Interfaces;

namespace WLMT.Bungalows.Application.UseCases.Campaigns.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Guid>
    {
        private readonly ICampaignRepository _repository;

        public CreateCampaignCommandHandler(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = new Campaign(request.Name, request.City, request.Budget);

            await _repository.AddAsync(campaign, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return campaign.Id;
        }
    }
}

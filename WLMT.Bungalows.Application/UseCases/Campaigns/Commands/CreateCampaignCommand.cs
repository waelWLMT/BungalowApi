using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace WLMT.Bungalows.Application.UseCases.Campaigns.Commands
{
    public record CreateCampaignCommand(string Name, string City, decimal Budget) : IRequest<Guid>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WLMT.Bungalows.Domain.Entities;
using WLMT.Bungalows.Domain.Interfaces;
using WLMT.Bungalows.Infrastructure.Persistence;

namespace WLMT.Bungalows.Infrastructure.Repositories
{
    public class CampaignReadRepository : ReadRepository<Campaign>, ICampaignReadRepository
    {
        public CampaignReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}

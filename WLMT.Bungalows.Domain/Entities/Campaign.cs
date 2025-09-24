using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLMT.Bungalows.Domain.Entities
{
    public class Campaign
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public decimal Budget { get; private set; }

        public Campaign(string name, string city, decimal budget)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (budget <= 0)
                throw new ArgumentException("Budget must be positive.", nameof(budget));

            Id = Guid.NewGuid();
            Name = name;
            City = city;
            Budget = budget;
        }
    }
}

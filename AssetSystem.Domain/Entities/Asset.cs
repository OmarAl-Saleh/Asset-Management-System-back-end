using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssets.Domain.Entities
{
    public  class Asset
    {
        public int Id { get; set;  }
        public string Name { get; set; }

        public string Code { get; set; }

        public string? Description { get; set;  }

        public DateTime PurchaseDate { get; set; }

        public decimal Value { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }


    }
}

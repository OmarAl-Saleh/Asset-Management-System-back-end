using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Application.DTOs
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string PurchaseDate { get; set; }
        public decimal Value { get; set; }

        public int CategoryId { get; set; }
        public int LocationId { get; set; }

        public string? CategoryName { get; set; }
        public string? LocationName { get; set; }
    }

    public class CreateAssetDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
    }

    public class UpdateAssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
    }

}

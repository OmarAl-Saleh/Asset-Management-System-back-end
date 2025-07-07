using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Application.DTOs
{
    public class DashboardDto
    {
        public int TotalUsers { get; set; }
        public int TotalActiveUsers { get; set; }
        public int TotalAssets { get; set; }
        public int TotalCategories { get; set; }
        public int TotalLocations { get; set; }
    }
}

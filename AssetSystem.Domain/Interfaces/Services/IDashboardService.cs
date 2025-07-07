using AssetSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Domain.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboardDataAsync();
    }
}

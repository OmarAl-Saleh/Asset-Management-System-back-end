using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Common.DTOs.Auth
{
    public class RefreshTokenRequest
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
    }
}

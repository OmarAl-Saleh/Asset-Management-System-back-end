using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Common.Responses
{
    public class JsonModel
    {
        public object? obj { get; set; }
        public int code { get; set; } // 1 = success, 0 = error
        public string strMessage { get; set; } = string.Empty;
    }
}

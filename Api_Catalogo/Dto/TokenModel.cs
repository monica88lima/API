using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TokenModel
    {
        
        public string? AcessToken { get; set; }
              
        public string? RefreshToken { get; set; }
    }
}

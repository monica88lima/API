using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class LoginModelDTO
    {
        [Required(ErrorMessage = "campo obrigátorio")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "campo obrigátorio")]
        public string? Passoword { get; set; }
    }
}

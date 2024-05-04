using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class RegistoUsuarioDTO
    {
        [Required(ErrorMessage = "campo obrigátorio")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "campo obrigátorio")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "campo obrigátorio")]
        public string? Password { get; set; }
    }
}

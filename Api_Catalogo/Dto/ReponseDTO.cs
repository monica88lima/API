using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ResponseDTO
    {
        public string? Message { get; set; }
        public string? Status { get; set; }
    }
}

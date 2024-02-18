using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CategoriaDTO
    {

        [Key]
        public int CategoriaId { get; set; }

        [MaxLength(80)]
        [MinLength(2, ErrorMessage = "O nome deve ter mais de {1} caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ImagemUrl { get; set; }
    }
}

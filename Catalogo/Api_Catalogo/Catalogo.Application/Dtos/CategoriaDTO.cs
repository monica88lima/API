using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Dtos
{
    public class CategoriaDTO : EntityDTO
    {
        [Required(ErrorMessage = "Nome é um dado Obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo deve ter de {2} a {1} caracteres",MinimumLength = 3)]
        public string? Nome { get; private set; }

        [Required(ErrorMessage = "Nome é um dado Obrigatório")]
        [StringLength(250, ErrorMessage = "O Campo deve ter de 3 a 250 caracteres", MinimumLength = 3)]
        [DisplayName("Endereço URL da Imagem")]
        public string? ImagemUrl { get; private set; }
        public ICollection<ProdutoDTO>? ProdutoDTO { get; set; }
    }
}

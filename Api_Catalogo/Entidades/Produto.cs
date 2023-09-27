using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [MaxLength(80)]
        [MinLength(3)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [MaxLength(300)]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public double Preco { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ImagemUrl { get; set; }

        public  float Estoque { get; set; }

        public DateTime DataCadastro { get; set; }= DateTime.Now;

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

    }
}

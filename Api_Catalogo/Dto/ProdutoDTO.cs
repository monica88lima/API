using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Entidades.Validacao;

namespace Dto
{
    public class ProdutoDTO
    {

        [Key]
        public int ProdutoId { get; set; }

        [MaxLength(80)]
        [MinLength(3, ErrorMessage = "O nome de possuir mais de {1} caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [LetraMaiuscula]
        public string? Nome { get; set; }

        [MaxLength(300)]
        public string? Descricao { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "O preço deve estar entre {1} e {2}")]
        [Column(TypeName = "decimal(10,2)")]
        public double Preco { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? ImagemUrl { get; set; }
        public int CategoriaId { get; set; }




    }
}

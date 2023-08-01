using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Catalogo.Application.Dtos
{
    public class ProdutoDTO:EntityDTO
    {
        [Required(ErrorMessage = "Nome é um campo Obrigatório")]
        [StringLength(250, ErrorMessage = "O Campo deve ter de 3 a 250 caracteres", MinimumLength = 3)]
        public string? Nome { get; private set; }

        [Required(ErrorMessage = "Descricão é um campo Obrigatório")]
        [StringLength(250, ErrorMessage = "O Campo deve ter de 3 a 250 caracteres", MinimumLength = 3)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; private set; }

        [Display(Name = "Informe o Preço")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayName("Preço")]
        public decimal Preco { get; private set; }

        [Required(ErrorMessage = "Imagem é um campo Obrigatório")]
        [StringLength(250, ErrorMessage = "O Campo deve ter de 3 a 250 caracteres", MinimumLength = 3)]
        [DisplayName("Endereço URL da Imagem")]
        public string? ImagemUrl { get; private set; }
    }
}

using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string? ImagemUrl { get; private set; }
        public float Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria? categoria { get;  set; }

        public void Update(string nome, string descricao, decimal preco, string imagemUrl,
                             float estque, DateTime dataCadastro, int categoriaId)
        {
            this.Nome= nome;
            this.Descricao = descricao;
            ValidateDomain(preco, dataCadastro, categoriaId);
            this.ImagemUrl = imagemUrl;
            this.Estoque = estque;
            
            
        }

        private void ValidateDomain(decimal preco, DateTime dataCadastro,int categoriaId)
        {

            DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");
            DomainExceptionValidation.When(dataCadastro != DateTime.Now, "A data de cadastro deve ser a data Atual");
            DomainExceptionValidation.When(categoriaId < 1, "Categoria Inválida");
            this.Preco = preco;
            this.DataCadastro = dataCadastro;
            this.CategoriaId = categoriaId;

        }
    }

  
}

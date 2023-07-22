using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities
{
    public sealed class Categoria : Entity
    {
        public string? Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public ICollection<Produto>? Produtos { get;  set; }

        public Categoria(string nome, string imagemUrl)
        {
            this.Nome = nome;
            this.ImagemUrl = imagemUrl;
        }
        public Categoria(int id,string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(id < 0, "Valor de Id Inválido!");
            this.Id = id;
            this.Nome = nome;
            this.ImagemUrl = imagemUrl;
        }

    }
}

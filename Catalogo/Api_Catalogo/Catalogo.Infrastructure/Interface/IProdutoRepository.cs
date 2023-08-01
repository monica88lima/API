using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.Interface
{
    public interface IProdutoRepository:IRepository<Produto>
    {
       Task<IEnumerable<Produto>> GetProductPrice();
    }
}

using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.Interface
{
    public interface ICategoriaRepository:IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriaProdutos();

    }
}

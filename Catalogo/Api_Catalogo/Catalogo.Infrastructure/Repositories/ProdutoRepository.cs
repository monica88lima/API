using Catalogo.Domain.Entities;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto) 
        {
                
        }
        public async Task<IEnumerable<Produto>> GetProductPrice()
        {
            return await Get().OrderBy(x => x.Preco).ToListAsync();
        }
    }
}

using Catalogo.Domain.Entities;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories
{
    public class CategoriaRepository:Repository<Categoria>,ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext contexto) : base(contexto)
        {

        }

        public async Task<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            return await Get().Include(x => x.Produtos).ToListAsync();
        }
    }
}

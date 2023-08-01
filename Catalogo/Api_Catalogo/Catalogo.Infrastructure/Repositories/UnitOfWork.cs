using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interface;

namespace Catalogo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository _produtoRep;
        private CategoriaRepository _categoriaRep;
        public readonly AppDbContext _context;
        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public ICategoriaRepository CategoriasRepository
        {
            get
            {
                return _categoriaRep = _categoriaRep ?? new CategoriaRepository(_context);
            }

        }


        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRep = _produtoRep ?? new ProdutoRepository(_context);
            }
        }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

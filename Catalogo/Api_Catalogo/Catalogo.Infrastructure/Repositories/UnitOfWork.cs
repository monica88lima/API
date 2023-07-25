using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private ProdutoRepository _produtoRep;
        private CategoriaRepository _categoriaRep;
        public AppDbContext _context;
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
              

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose() 
        { 
            _context.Dispose();
        }
    }
}

using Entidades;
using Repositorio.Contexto;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Altera(Produto produto)
        {
            if(produto is null )
                new ArgumentNullException(nameof(produto));
            if(_appDbContext.Produtos.Any(p => p.ProdutoId == produto.ProdutoId))
            {
                _appDbContext.Produtos.Update(produto);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Produto> BuscaProduto()
        {
            return _appDbContext.Produtos;
        }

        public Produto BuscaProdutoID(int id)
        {
            return _appDbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);
        }

        public Produto CriaProduto(Produto produto)
        {
            if (produto is null)
                new ArgumentNullException(nameof(produto));

            _appDbContext.Produtos.Add(produto);
            _appDbContext.SaveChanges();
            return produto;
        }

        public bool Deleta(int id)
        {
            var produto = _appDbContext.Produtos.Find(id);
            if(produto is null)  
                return false; 

            _appDbContext.Produtos.Remove(produto);
            _appDbContext.SaveChanges();
            return true;
        }
    }
}

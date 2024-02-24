using Entidades;
using Microsoft.EntityFrameworkCore;
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
            return _appDbContext.Produtos.AsNoTracking();
        }

        public Produto BuscaProdutoID(int id)
        {
            return _appDbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);
        }
        public IQueryable<Produto> BuscaProdutoFiltro(string nome = null, string descricao = null, float preco = 0, int estoque = 0) 
        {
            //var query = _appDbContext.Produtos.AsQueryable();
            //if(nome is not null )
            //  query.Where(p => p.Nome == nome);

            //return query;
            StringBuilder query = new StringBuilder();
            query.Append("Select * from Produtos where 1 = 1 ");


            if(nome is not null )
                query.Append( $" and nome like {"'%" + nome + "%'"} ");
            if (descricao is not null)
                query.Append($" and descricao like {"'%" + descricao + "%'"} ");
            //tratar preco, dando erro
            if (preco > 0)
                query.Append($" and preco ={preco} ");
            if (estoque > 0)
                query.Append($" and estoque ={estoque} ");

            return _appDbContext.Produtos.FromSqlRaw(query.ToString());
            
        }    

        public IEnumerable<Produto> BuscaProdutoPaginado(Paginacao pg)
        {
            return BuscaProduto()
                 .OrderBy(p => p.Nome)
                 .Skip((pg.numeroPg - 1) * pg.tamanhoPg)
                 .Take(pg.tamanhoPg).ToList();
            // a linha do skip que controla a quantidade de pagina que deve pular
                
        }

        public Produto CriaProduto(Produto produto)
        {
            if (produto is null)
                throw new InvalidOperationException("Produto Invalido");

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

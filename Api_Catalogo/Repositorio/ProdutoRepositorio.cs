using Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<bool> Altera(Produto produto)
        {
            if (produto is null)
                new ArgumentNullException(nameof(produto));
            if (_appDbContext.Produtos.Any(p => p.ProdutoId == produto.ProdutoId))
            {
                _appDbContext.Produtos.Update(produto);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Produto>> BuscaProduto()
        {
            return await _appDbContext.Produtos.AsNoTracking().ToListAsync();
        }
        public IQueryable<Produto> BuscaProduto2()
        {
            return _appDbContext.Produtos.AsNoTracking();
        }

        public async Task<Produto> BuscaProdutoID(int id)
        {
            return await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
        }
        public async Task<List<Produto>> BuscaProdutoFiltro(string? nome = null, string? descricao = null, float preco = 0, int estoque = 0)
        {
            //var query = _appDbContext.Produtos.AsQueryable();
            //if(nome is not null )
            //  query.Where(p => p.Nome == nome);

            //return query;

            StringBuilder query = new StringBuilder();
            query.Append("Select * from Produtos where 1 = 1 ");
            if (nome is not null)
                query.Append($" and nome like {"'%" + nome + "%'"} ");
            if (descricao is not null)
                query.Append($" and descricao like {"'%" + descricao + "%'"} ");
            //tratar preco, dando erro
            if (preco > 0)
                query.Append($" and preco ={preco.ToString(CultureInfo.InvariantCulture)} ");
            if (estoque > 0)
                query.Append($" and estoque ={estoque} ");

            return await _appDbContext.Produtos.FromSqlRaw(query.ToString()).ToListAsync();

        }

        public IEnumerable<Produto> BuscaProdutoPaginado(Paginacao pg)
        {
            return BuscaProduto2()
                 .OrderBy(p => p.Nome)
                 .Skip((pg.numeroPg - 1) * pg.tamanhoPg)
                 .Take(pg.tamanhoPg).ToList();
            // a linha do skip que controla a quantidade de pagina que deve pular

        }

        public async Task<Produto> CriaProduto(Produto produto)
        {
            if (produto is null)
                throw new InvalidOperationException("Produto Invalido");

            _appDbContext.Produtos.Add(produto);
            await _appDbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeletaAsync(int id)
        {
            var produto = await _appDbContext.Produtos.FindAsync(id);
            if (produto is null)
                return false;

            _appDbContext.Produtos.Remove(produto);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

      
    }
}

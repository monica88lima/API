using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interface
{
    public interface IProdutoRepositorio
    {
        
        Task<bool> Altera(Produto produto);
        Task<IEnumerable<Produto>> BuscaProduto();
        IQueryable<Produto> BuscaProduto2();
        Task<Produto> BuscaProdutoID(int id);
        Task<List<Produto>> BuscaProdutoFiltro(string? nome = null, string? descricao = null, float preco = 0, int estoque = 0);
        IEnumerable<Produto> BuscaProdutoPaginado(Paginacao pg);
        Task<Produto> CriaProduto(Produto produto);
        Task<bool> DeletaAsync(int id);
    }
}

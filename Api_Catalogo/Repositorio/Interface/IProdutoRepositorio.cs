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
        IQueryable<Produto> BuscaProduto();
        Produto BuscaProdutoID(int id);
        Produto CriaProduto (Produto produto);
        bool Altera (Produto produto);
        bool Deleta (int  id);
    }
}

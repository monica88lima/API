using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interface
{
    public interface ICategoriaRepositorio
    {
        //IEnumerable=abstracao  generica de list, colecao,dicionario
        Task<IEnumerable<Categoria>> PesquisarTodasCategorias();
        Task<Categoria> PesquisarCategoria(int id);
        Task<Categoria> Criar(Categoria categoria);
        Task<Categoria> Alterar(Categoria categoria);
        Task<Categoria> Deletar(int id);
        Task<IEnumerable<Categoria>> PesquisarTodasCategoriasEProduto();
    }
}

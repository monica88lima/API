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
        IEnumerable<Categoria> PesquisarTodasCategorias();
        Categoria PesquisarCategoria(int id);
        Categoria Criar(Categoria categoria);
        Categoria Alterar(Categoria categoria);
        Categoria Deletar(int id);
        IEnumerable<Categoria> PesquisarTodasCategoriasEProduto();
    }
}

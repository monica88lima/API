using Catalogo.Application.Dtos;

namespace Catalogo.Application.Interfaces
{
    public interface IProdutoSevice
    {
         Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetProdutosID(int id);
    }
}

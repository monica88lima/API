namespace Catalogo.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriasRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        Task Commit();
        
    }
}

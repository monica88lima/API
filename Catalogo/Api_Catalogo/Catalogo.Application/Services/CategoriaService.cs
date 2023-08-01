using Catalogo.Infrastructure.Repositories;

namespace Catalogo.Application.Services
{
    public class CategoriaService
    {
        private readonly UnitOfWork _uof;
        public CategoriaService(UnitOfWork context)
        {
           
            _uof = context;

        }
                   
    
    }
    
}

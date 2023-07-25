using Catalogo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using AutoMapper;
using Catalogo.Application.Dtos;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutosController : ControllerBase
    {
        
        

        public ProdutosController( )
        {
            
            
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> GetProdutos()
        {
            
            
            
        }
    }
}

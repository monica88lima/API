using Catalogo.Application.Dtos;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoSevice _produtoService;


        public ProdutosController(IProdutoSevice produtoService)
        {
            _produtoService = produtoService;

        }

        [HttpGet]
        public async  Task<ActionResult<List<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.GetProdutos();
            return Ok(produtos);


        }
        [HttpGet("Id")]
        public async Task<ActionResult<ProdutoDTO>> GetProdutosId(int id)
        {
            var produto = await _produtoService.GetProdutosID(id);
            return Ok(produto);


        }


    }
}

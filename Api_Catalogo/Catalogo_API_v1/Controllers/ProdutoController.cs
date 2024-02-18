using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Catalogo_API_v1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoController(IProdutoRepositorio context)
        {
            _repositorio = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _repositorio.BuscaProduto();
                if (produtos is null)
                {
                    return NotFound("Nenhum produto localizado");
                }
                return Ok(produtos);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }


        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _repositorio.BuscaProdutoID(id);
                if (produto is null)
                {
                    return NotFound($"Produto com id:{id}, não localizado");
                }
                return produto;

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post(Produto prod)
        {
            try
            {
                if (prod is null)
                {
                    return BadRequest("Dados inválidos");
                }
                _repositorio.CriaProduto(prod);

                return new CreatedAtRouteResult("ObterProduto",
                    new { id = prod.ProdutoId }, prod);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto prod)
        {
            try
            {
                if (id != prod.ProdutoId)
                {
                    return BadRequest();
                }
               bool sucess = _repositorio.Altera(prod);
                if (sucess) 
                    return Ok(prod); 
                else 
                    return StatusCode(500, $"Falha ao atualizar produto de id= {id}");
  

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var produto = _repositorio.BuscaProdutoID(id);
                if (produto is null)
                {
                    return NotFound($"Produto com id:{id}, não localizado");
                }

               bool sucess =  _repositorio.Deleta(id);
                if (sucess)
                    return Ok(produto);
                else
                    return StatusCode(500, $"Falha ao tentar deletar produto de id= {id}");
              
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            
        }


    }
}

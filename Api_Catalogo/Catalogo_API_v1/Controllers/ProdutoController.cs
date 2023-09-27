using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;

namespace Catalogo_API_v1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos.ToList();
                if (produtos is null)
                {
                    return NotFound();
                }
                return produtos;

            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
                if (produto is null)
                {
                    return NotFound();
                }
                return produto;

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Post(Produto prod)
        {
            try
            {
                if (prod is null)
                {
                    return BadRequest();
                }
                _context.Produtos.Add(prod);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto",
                    new { id = prod.ProdutoId }, prod);

            }
            catch (Exception)
            {

                throw;
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
                _context.Entry(prod).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(prod);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
                if (produto is null)
                {
                    return NotFound();
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok(produto);

            }
            catch (Exception)
            {

                throw;
            }
            
        }


    }
}

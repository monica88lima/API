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
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            try
            {
                var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
                if (produtos is null)
                {
                    return NotFound("Nenhum produto localizado");
                }
                return produtos;

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }


        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            try
            {
                var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.ProdutoId == id);
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
                _context.Produtos.Add(prod);
                _context.SaveChanges();

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
                _context.Entry(prod).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(prod);

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
                var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
                if (produto is null)
                {
                    return NotFound($"Produto com id:{id}, não localizado");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok(produto);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            
        }


    }
}

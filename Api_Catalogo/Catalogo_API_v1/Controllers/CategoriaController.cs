using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Services;

namespace Catalogo_API_v1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMeuServico _meuServico;

        public CategoriaController(AppDbContext context, IMeuServico meuServico)
        {
            _context = context;
            _meuServico = meuServico;
        }
        [HttpGet("SemUso/{nome}")]
        public ActionResult<string> GetSaudacaoFrom(IMeuServico meuServico, string nome) {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("UsandoFromServices/{nome}")]
        public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProdutos()
        {
            try
            {
                return await _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToListAsync();
                
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação");
               
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            try
            {
                var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
                if (categorias is null)
                {
                    return NotFound($"Nenhuma Categoria Localizada!");
                }
                return categorias;


            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }


        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            try
            {
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.CategoriaId == id);
                if (categoria is null)
                {
                    return NotFound($"Categoria com id:{id}, não localizado");
                }
                return Ok(categoria);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post(Categoria cat)
        {
            try
            {
                if (cat is null)
                {
                    return BadRequest("Dados inválidos");
                }
                 _context.Categorias.Add(cat);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = cat.CategoriaId }, cat);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest("Dados inválidos");
                }
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(categoria);

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
                var categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
                if (categoria is null)
                {
                    return NotFound($"Categoria com id:{id}, não localizado");
                }

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return Ok(categoria);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}

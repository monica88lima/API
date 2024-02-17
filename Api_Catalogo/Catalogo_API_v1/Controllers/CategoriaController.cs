using Catalogo_API_v1.Filtro;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interface;
using Services;

namespace Catalogo_API_v1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _repositorio;
        private readonly IMeuServico _meuServico;
        private readonly ILogger _logger;

        public CategoriaController(ICategoriaRepositorio context, IMeuServico meuServico, ILogger<CategoriaController> logger)
        {
            _repositorio = context;
            _meuServico = meuServico;
            _logger = logger;
        }
        [HttpGet("SemUso/{nome}")]
        public ActionResult<string> GetSaudacaoFrom(IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);

        }

        [HttpGet("UsandoFromServices/{nome}")]
        public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {

            return _repositorio.PesquisarTodasCategoriasEProduto().ToList();


        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFiltro))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {

            var categorias =  _repositorio.PesquisarTodasCategorias().ToList();
            if (categorias is null)
            {
                return NotFound($"Nenhuma Categoria Localizada!");
            }
            return Ok(categorias);





        }


        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            _logger.LogInformation($"### chamada Categoria por id = {id}");


            var categoria = _repositorio.PesquisarCategoria(id);
            if (categoria is null)
            {
                _logger.LogInformation($"### chamada Categoria por id = {id} - NotFound");
                return NotFound($"Categoria com id:{id}, não localizado");
            }
            return Ok(categoria);


        }
        [HttpPost]
        public ActionResult Post(Categoria cat)
        {

            if (cat is null)
            {
                _logger.LogWarning($"Dados Invalidos");
                return BadRequest("Dados inválidos");
            }
           var categoriaCriada =  _repositorio.Criar(cat);
          

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoriaCriada.CategoriaId }, categoriaCriada);



        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {

            if (id != categoria.CategoriaId)
            {
                _logger.LogWarning($"Dados Inválidos");
                return BadRequest("Dados inválidos");
            }
            _repositorio.Alterar(categoria);  
           

            return Ok(categoria);



        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var categoria = _repositorio.PesquisarCategoria(id);
            if (categoria is null)
            {
                _logger.LogWarning($"Categoria: {id} inválida");
                return NotFound($"Categoria com id:{id}, não localizado");
            }

            _repositorio.Deletar(id);
           

            return Ok(categoria);


        }
    }
}

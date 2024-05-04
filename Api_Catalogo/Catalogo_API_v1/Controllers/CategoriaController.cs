using AutoMapper;
using Catalogo_API_v1.Filtro;
using Dto;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interface;
using Services.Interface;

namespace Catalogo_API_v1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _repositorio;
        private readonly IMeuServico _meuServico;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepositorio context, IMeuServico meuServico, ILogger<CategoriaController> logger, IMapper mapper)
        {
            _repositorio = context;
            _meuServico = meuServico;
            _logger = logger;
            _mapper = mapper;
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
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        {

            var Categorias = await _repositorio.PesquisarTodasCategoriasEProduto();
            if (Categorias is null)
            {
                //mapeando as entidades manualmente
                var categoriaDto = new List<CategoriaDTO>();
                foreach (var categoria in Categorias)
                {
                    var cateDto = new CategoriaDTO()
                    {
                        Nome = categoria.Nome,
                        ImagemUrl = categoria.ImagemUrl,
                        CategoriaId = categoria.CategoriaId,

                    };
                    categoriaDto.Add(cateDto);
                    //adicionada cada objeto mapeado na lista
                }
                return Ok(categoriaDto);
            }
            return NotFound($"Nenhuma Categoria Localizada!");

        }
        [Authorize]
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFiltro))]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {

            var categorias = await _repositorio.PesquisarTodasCategorias();
            if (categorias is null)
            {
                return NotFound($"Nenhuma Categoria Localizada!");
            }
            var categoriaDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriaDto);


        }


        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            _logger.LogInformation($"### chamada Categoria por id = {id}");


            var categoria = await _repositorio.PesquisarCategoria(id);
            if (categoria is null)
            {
                _logger.LogInformation($"### chamada Categoria por id = {id} - NotFound");
                return NotFound($"Categoria com id:{id}, não localizado");
            }
            //mapeando a entidade Categoria p/ CategoriaDto de forma manual
            var categoriaDto = new CategoriaDTO() 
            { 
                CategoriaId = categoria.CategoriaId,
                ImagemUrl = categoria.ImagemUrl,
                Nome = categoria.Nome 
            }; 
            return Ok(categoriaDto);


        }
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> Post(CategoriaDTO cat)
        {

            if (cat is null)
            {
                _logger.LogWarning($"Dados Invalidos");
                return BadRequest("Dados inválidos");
            }
            //Mapeio a entidade DTo para Model
           var Categoria =  _mapper.Map<Categoria>(cat);
            //crio na base
           var categoriaCriada = await _repositorio.Criar(Categoria);
            //mapeio para fazer o retorno da entidade no model dto
            var CategoriaNova = _mapper.Map<CategoriaDTO>(categoriaCriada);


            return new CreatedAtRouteResult("ObterCategoria",
                new { id = CategoriaNova.CategoriaId }, CategoriaNova);

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Put(int id, CategoriaDTO categoria)
        {

            if (id != categoria.CategoriaId)
            {
                _logger.LogWarning($"Dados Inválidos");
                return BadRequest("Dados inválidos");
            }
            var Categoria = _mapper.Map<Categoria>(categoria);
            await _repositorio.Alterar(Categoria);

            var CategoriaNova = _mapper.Map<CategoriaDTO>(Categoria);


            return Ok(CategoriaNova);



        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaDTO> Delete(int id)
        {

            var categoria = _repositorio.PesquisarCategoria(id);
            if (categoria is null)
            {
                _logger.LogWarning($"Categoria: {id} inválida");
                return NotFound($"Categoria com id:{id}, não localizado");
            }

            _repositorio.Deletar(id);
            var Categoria = _mapper.Map<Categoria>(categoria);

            return Ok(Categoria);


        }
    }
}

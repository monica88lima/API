using AutoMapper;
using Dto;
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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepositorio context, IMapper mapper)
        {
            _repositorio = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            try
            {
                var produtos = await _repositorio.BuscaProduto();
                if (produtos is null)
                {
                    return NotFound("Nenhum produto localizado");
                }
                //mapper var destino = _mapper.Map<Destino>(origem)
                var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
                return Ok(produtosDto);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }


        }
        [HttpGet("ProdutosPaginado")]
        public ActionResult<IEnumerable<ProdutoDTO>> BuscarProdutosPg([FromQuery] Paginacao produtosParametros)
        {
            var produtos = _repositorio.BuscaProdutoPaginado(produtosParametros);
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            return Ok(produtosDto);
        }
        [HttpGet("ProdutoFiltro")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> ProdutoComFiltro(string nome=null, string descricao=null, float preco =0, int estoque =0)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(descricao) && preco <=0 && estoque <= 0)
                {
                    return BadRequest("Dados inválidos");
                }
                               
                var produtos = await _repositorio.BuscaProdutoFiltro(nome, descricao, preco, estoque) ;
                if(produtos.Count == 0)
                {
                    return NotFound($"Nenhum produto localizado.");
                }
                var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

                return Ok(produtosDto);

            }
            catch (Exception)
            {

                throw;
            }
           
          
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            try
            {
                var produto = await _repositorio.BuscaProdutoID(id);
                if (produto is null)
                {
                    return NotFound($"Produto com id:{id}, não localizado");
                }
                var produtoDto = _mapper.Map<ProdutoDTO>(produto);
                return produtoDto;

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post(ProdutoDTO prod)
        {
            try
            {
                if (prod is null)
                {
                    return BadRequest("Dados inválidos");
                }
                var produto =_mapper.Map<Produto>(prod);
                await _repositorio.CriaProduto(produto);

                var produtoDtoNovo = _mapper.Map<ProdutoDTO>(produto);

                return new CreatedAtRouteResult("ObterProduto",
                    new { id = produtoDtoNovo.ProdutoId }, produtoDtoNovo);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Put(int id, ProdutoDTO prod)
        {
            try
            {
                if (id != prod.ProdutoId)
                {
                    return BadRequest();
                }
                var produto = _mapper.Map<Produto>(prod);
                bool sucess = await _repositorio.Altera(produto);
                var produtoAtualizadoDto = _mapper.Map<ProdutoDTO>(produto);
                if (sucess) 
                    return Ok(produtoAtualizadoDto); 
                else 
                    return StatusCode(500, $"Falha ao atualizar produto de id= {id}");
  

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            try
            {
                var produto = _repositorio.BuscaProdutoID(id);
                if (produto is null)
                {
                    return NotFound($"Produto com id:{id}, não localizado");
                }
                var produtoDto = _mapper.Map<ProdutoDTO>(produto);
                bool sucess =  await _repositorio.DeletaAsync(id);
                if (sucess)
                    return Ok(produtoDto);
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

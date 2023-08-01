using AutoMapper;
using Catalogo.Application.Dtos;
using Catalogo.Application.Interfaces;
using Catalogo.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Services
{
    public class ProdutoService: IProdutoSevice
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ProdutoService(IUnitOfWork context, IMapper mapper)
        {

            _uof = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtos= await _uof.ProdutoRepository.Get().ToListAsync();
            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);
            return produtosDto;

        }

        public async Task<ProdutoDTO> GetProdutosID(int id)
        {
            var produtos = await _uof.ProdutoRepository.GetById(x => x.Id == id);
            var produtosDto = _mapper.Map<ProdutoDTO>(produtos);
            return produtosDto;

        }
    }
}

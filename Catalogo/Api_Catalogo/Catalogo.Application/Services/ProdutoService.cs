using AutoMapper;
using Catalogo.Application.Dtos;
using Catalogo.Domain.Entities;
using Catalogo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Services
{
    public class ProdutoService
    {
        private readonly UnitOfWork _uof;
        private readonly IMapper _mapper;
        public ProdutoService(UnitOfWork context, IMapper mapper)
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
    }
}

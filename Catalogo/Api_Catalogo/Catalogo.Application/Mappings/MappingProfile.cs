using AutoMapper;
using Catalogo.Application.Dtos;
using Catalogo.Domain.Entities;

namespace Catalogo.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
                CreateMap<Produto,ProdutoDTO>().ReverseMap();
                CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }

    }
}

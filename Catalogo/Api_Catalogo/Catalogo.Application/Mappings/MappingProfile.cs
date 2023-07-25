using AutoMapper;
using Catalogo.Application.Dtos;
using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

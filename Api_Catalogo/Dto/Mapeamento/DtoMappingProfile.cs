using AutoMapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Mapeamento
{
   public class DtoMappingProfile:Profile
    {
        public DtoMappingProfile() {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria > ().ReverseMap();

        }

    }
}

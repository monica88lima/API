﻿using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Interface
{
    public interface ICategoriaRepository:IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriaProdutos();

    }
}

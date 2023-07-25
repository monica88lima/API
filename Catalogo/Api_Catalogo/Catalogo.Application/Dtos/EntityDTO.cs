using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Dtos
{
    public abstract class EntityDTO
    {
        [Key]
        public int Id { get; protected set; }
    }
}

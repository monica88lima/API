using System.ComponentModel.DataAnnotations;

namespace Catalogo.Application.Dtos
{
    public abstract class EntityDTO
    {
        [Key]
        public int Id { get; protected set; }
    }
}

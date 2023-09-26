﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        public Categoria()
        {
           Produtos = new Collection<Produto>();
        }
        [Key] 
        public int CategoriaId { get; set; }

        [MaxLength(80)]
        [MinLength(2)]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }
        [MaxLength(300)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ImagemUrl { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}

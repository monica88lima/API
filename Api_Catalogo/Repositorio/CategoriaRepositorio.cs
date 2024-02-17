using Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public Categoria Alterar(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            //para acompanhar uma entidade nao rastreada pelo contexto
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return categoria;
        }

        public Categoria Criar(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria Deletar(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria PesquisarCategoria(int id)
        {
            return _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
        }

        public IEnumerable<Categoria> PesquisarTodasCategorias()
        {
            return _context.Categorias.ToList();
        }
        public IEnumerable<Categoria> PesquisarTodasCategoriasEProduto()
        {
            return _context.Categorias.AsNoTracking().Include(x => x.Produtos).ToList();
        }
    }
}

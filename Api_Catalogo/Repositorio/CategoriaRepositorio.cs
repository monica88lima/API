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

        public async Task<Categoria> Alterar(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            //para acompanhar uma entidade nao rastreada pelo contexto
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Criar(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Deletar(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> PesquisarCategoria(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);
        }

        public async Task<IEnumerable<Categoria>> PesquisarTodasCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Categoria>> PesquisarTodasCategoriasEProduto()
        {
            return await _context.Categorias.AsNoTracking().Include(x => x.Produtos).ToListAsync();
        }
    }
}

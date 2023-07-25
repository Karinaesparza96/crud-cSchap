using AppLivro.Data;
using AppLivro.Models;
using AppLivro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppLivro.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroContext _context;
        public LivroRepository(LivroContext context) 
        { 
            _context = context;
        }

        public List<Models.Livro> GetAll()
        {
            var livroContext = _context.Livros.Include(l => l.Autor);
            return livroContext.ToList();
        }

        public Models.Livro GetById(int id) 
        {

            var livro =  _context.Livros
                .Include(l => l.Autor)
                .FirstOrDefault(m => m.Id == id);

            return livro;
        }

        public void Create(Models.Livro livro) 
        {
            _context.Add(livro);
           _context.SaveChanges();

        }

        public void Edit(Models.Livro livro)
        {
            _context.Update(livro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var livro = GetById(id);
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Livros.Any(l => l.Id == id);    
        }
    }
}

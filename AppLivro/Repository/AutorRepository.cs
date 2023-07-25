using AppLivro.Data;
using AppLivro.Models;
using AppLivro.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AppLivro.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LivroContext _context;
        public AutorRepository(LivroContext context) 
        {
            _context = context;
        }

        public List<Models.Autor> GetAll()
        {
            return _context.Autores.ToList();
        }

        public Autor GetById(int id) 
        {
            return _context.Autores
                .FirstOrDefault(a => a.Id == id);
        }

        public void Create(Autor autor)
        {
            _context.Add(autor);
            _context.SaveChanges();
        }

 
        public void Edit(Autor autor) 
        {
            _context.Update(autor);
            _context.SaveChanges();

        }

        public void Delete(int id) 
        {
            var autor = GetById(id);
            _context.Autores.Remove(autor);
            _context.SaveChanges();
        }

        public bool Exists(int id) 
        {
           return _context.Autores.Any(e => e.Id == id);
        }
    }
}

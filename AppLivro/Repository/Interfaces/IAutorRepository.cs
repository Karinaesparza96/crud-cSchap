using AppLivro.Models;
using System.Collections.Generic;

namespace AppLivro.Repository.Interfaces
{
    public interface IAutorRepository
    {
       public List<Models.Autor> GetAll();
        public Autor GetById(int id);

        public void Create(Autor autor);

        public void Edit(Autor autor);

        public void Delete(int id);

        public bool Exists(int id);
    }
}

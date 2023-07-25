using System.Collections.Generic;

namespace AppLivro.Repository.Interfaces
{
    public interface ILivroRepository
    {
        public List<Models.Livro> GetAll();

        public Models.Livro GetById(int id);

        public void Create(Models.Livro livro);

        public void Edit(Models.Livro livro);

        public void Delete(int id);

        public bool Exists(int id);
    }
}

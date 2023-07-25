using AppLivro.Models;
using System.Collections.Generic;

namespace AppLivro.DTO
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<LivroDTO> Livros { get; set; }
    }
}

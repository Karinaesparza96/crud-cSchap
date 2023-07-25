using AppLivro.Models;
using System.ComponentModel;

namespace AppLivro.DTO
{
    public class LivroDTO
    {
        public int Id { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Autor")]
        public int AutorId { get; set; }
        public AutorDTO Autor { get; set; }
    }
}

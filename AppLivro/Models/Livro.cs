using System.ComponentModel;

namespace AppLivro.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}

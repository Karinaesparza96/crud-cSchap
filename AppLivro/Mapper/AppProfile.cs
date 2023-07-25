using AppLivro.DTO;
using AutoMapper;

namespace AppLivro.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile() 
        {
            CreateMap<Models.Autor, AutorDTO>();
            CreateMap<Models.Livro, LivroDTO>();
        }
    }
}

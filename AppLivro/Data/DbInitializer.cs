
namespace AppLivro.Data

{
    public static class DbInitializer
    {
        public static void Initialize(LivroContext context)
        {
            context.Database.EnsureCreated();
           
        }
    }
}

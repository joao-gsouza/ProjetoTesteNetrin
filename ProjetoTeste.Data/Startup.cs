using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoTeste.Data
{
    public static class Startup
    {
        public static void RegisterData(this IServiceCollection services)
        {

            services.AddDbContext<ProjetoTesteContext>(opt =>
            {
                opt.UseInMemoryDatabase("Banco");
            });

        }
    }
}

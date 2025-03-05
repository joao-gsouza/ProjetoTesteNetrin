using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Service.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Service
{
    public static class Startup
    {
        public static void AddProjetoTesteServices(this IServiceCollection services)
        {
            ConsultaServiceCollection.Configure(services);
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Service.Consultas.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Service.Consultas
{
    public static class ConsultaServiceCollection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
        }

    }
}

using ProjetoTeste.Models.Data;
using ProjetoTeste.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Models.Conversor
{
    public class ClienteConversor
    {
        public static List<ClienteResponse> EntityListToReponseList(IEnumerable<Cliente> listaDeCliente)
        {
            return listaDeCliente.Select(x => EntityToResponse(x)).ToList();
        }

        public static ClienteResponse EntityToResponse(Cliente cliente)
        {
            return new ClienteResponse() 
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
            };
        }

    }
}

using ProjetoTeste.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Service.Consultas.Cliente
{
    public interface IClienteService
    {
        public Task<List<Models.Data.Cliente>> ConsulteLista();
        public Task<Models.Data.Cliente?> ConsultaPorId(int id);
        public Task<Models.Data.Cliente?> Inserir(ClienteRequest clienteRequest);
        public Task<bool> Deletar(int id);
        public Task<Models.Data.Cliente?> Atualizar(ClienteUpdateRequest clienteRequest);
    }
}

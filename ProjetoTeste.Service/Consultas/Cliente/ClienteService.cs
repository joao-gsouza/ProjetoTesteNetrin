using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Data;
using ProjetoTeste.Models.Request;

namespace ProjetoTeste.Service.Consultas.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly ProjetoTesteContext _context;

        public ClienteService(ProjetoTesteContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Data.Cliente>> ConsulteLista()
        {
            try
            {
                var result = await _context.Cliente.ToListAsync();

                return result;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<Models.Data.Cliente?> ConsultaPorId(int id)
        {
            try
            {
                var result = await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Models.Data.Cliente?> Inserir(ClienteRequest clienteRequest)
        {
            try
            {
                var result = await _context.Cliente.AddAsync(new Models.Data.Cliente 
                {
                    Nome = clienteRequest.Nome,
                    Email = clienteRequest.Email,
                    Telefone = clienteRequest.Telefone
                });

                if (await _context.SaveChangesAsync() > 0)
                {
                    return result.Entity;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Deletar(int id)
        {
            try
            {
                var clientePersistido = await ConsultaPorId(id);

                if (clientePersistido is not null)
                {
                    _context.Cliente.Remove(clientePersistido);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Models.Data.Cliente?> Atualizar(ClienteUpdateRequest clienteRequest)
        {
            try
            {
                var clientePersistido = await ConsultaPorId(clienteRequest.Id);

                if (clientePersistido is not null)
                {

                    clientePersistido.Nome = clienteRequest.Nome ?? clientePersistido.Nome;
                    clientePersistido.Email = clienteRequest.Email ?? clientePersistido.Email;
                    clientePersistido.Telefone = clienteRequest.Telefone ?? clientePersistido.Telefone;

                    var result = _context.Cliente.Update(clientePersistido);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return result.Entity;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Data
{
    public class ProjetoTesteContext : DbContext
    {
        public ProjetoTesteContext(DbContextOptions<ProjetoTesteContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Models.Request
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "Nome é Obrigatorio", AllowEmptyStrings = false)]
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ProjetoTeste.Models.Sistema
{
    public sealed class Erro
    {
        public Erro(string mensagem)
        {
            Mensagem = mensagem;
        }

        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
    }
}

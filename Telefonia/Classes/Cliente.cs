using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonia.Classes
{
    public class Cliente
    {
        public Cliente(string nome, string email, string dataNascimento, string? telefone = null)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        [JsonProperty("Data_Nasc")]
        public string DataNascimento { get; set; }
        public string? Telefone { get; set; }

        public void Resultado()
        {
            Console.WriteLine(Nome);
            Console.WriteLine(Email);
            Console.WriteLine(DataNascimento);
            Console.WriteLine(Telefone);
        }
    }
}

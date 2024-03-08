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
        //Aqui criamos o construtor de Cliente com todos os dados
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

        //Aqui temos o Método Resultado, que é responsável por mostrar o resultado obtido
        public void Resultado()
        {
            Console.WriteLine(Nome);
            Console.WriteLine(Email);
            Console.WriteLine(DataNascimento);
            Console.WriteLine(Telefone);
        }
    }
}

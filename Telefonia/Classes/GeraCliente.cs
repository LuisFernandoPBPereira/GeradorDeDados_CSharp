using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonia.Classes
{
    public class GeraCliente
    {
        /*
         * Aqui temos o Método GetCliente, que é responsável por consumir o arquivo
         * JSON com os clientes existentes
        */
        public string[] GetCliente()
        {
            //Usamos StreamReader do System.IO
            using (StreamReader sr = new StreamReader("../../../JSONs/clientes.json"))
            {
                //Lemos o arquivo e criamos as devidas variáveis 
                var json = sr.ReadToEnd();
                var list = new List<Cliente>();
                string[] array = new string[4];
                string nome, email, dataNasc, telefone;
                Random rnd = new Random();
                var tel = new GeraTelefone();

                //Deserializamos o arquivo em uma lista do tipo Cliente
                list = JsonConvert.DeserializeObject<List<Cliente>>(json);

                //Criamos um índice para pegarmos apenas um cliente
                int indice = rnd.Next(list.Count);

                nome = list[indice].Nome;
                email = list[indice].Email;
                dataNasc = list[indice].DataNascimento;
                //Parâmetros: UF, Telefone Fixo, Com DDD, Com Traço
                telefone = tel.Telefone("SP", false, false, true);

                //Passamos os dados para um array, para retornarmos ao construtor
                array[0] = nome;
                array[1] = email;
                array[2] = dataNasc;
                array[3] = telefone;

                return array;
            }
        }
    }
}

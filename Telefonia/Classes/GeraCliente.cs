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
            using (StreamReader streamReader = new StreamReader("../../../JSONs/clientes.json"))
            {
                //Lemos o arquivo e criamos as devidas variáveis 
                var json = streamReader.ReadToEnd();
                var listaClientes = new List<Cliente>();
                string[] dadosCliente = new string[4];
                string nome, email, dataNasc, telefone, uf;
                Random random = new Random();
                var tel = new GeraTelefone();

                bool telefoneFixo = false, 
                     comDdd       = false, 
                     comTraco     = false;

                //Deserializamos o arquivo em uma lista do tipo Cliente
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                //Criamos um índice para pegarmos apenas um cliente
                int indice = random.Next(listaClientes.Count);

                nome = listaClientes[indice].Nome;
                email = listaClientes[indice].Email;
                dataNasc = listaClientes[indice].DataNascimento;

                uf = "SP";

                telefone = tel.Telefone(uf, telefoneFixo, comDdd, comTraco);

                //Passamos os dados para um array, para retornarmos ao construtor
                dadosCliente[0] = nome;
                dadosCliente[1] = email;
                dadosCliente[2] = dataNasc;
                dadosCliente[3] = telefone;

                return dadosCliente;
            }
        }
    }
}

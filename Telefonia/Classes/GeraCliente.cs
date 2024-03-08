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
        public string[] GetCliente()
        {
            using (StreamReader sr = new StreamReader("../../../JSONs/clientes.json"))
            {
                var json = sr.ReadToEnd();
                var list = new List<Cliente>();

                list = JsonConvert.DeserializeObject<List<Cliente>>(json);

                string[] array = new string[4];
                int cont = 0;

                Random rnd = new Random();

                string nome, email, dataNasc, telefone;

                int indice = rnd.Next(list.Count);

                nome = list[indice].Nome;
                email = list[indice].Email;
                dataNasc = list[indice].DataNascimento;
                var tel = new GeraTelefone();
                

                array[0] = nome;
                array[1] = email;
                array[2] = dataNasc;
                array[3] = tel.Telefone("SP", true, true, false);

                return array;
            }
        }
    }
}

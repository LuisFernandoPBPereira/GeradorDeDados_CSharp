using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonia.Classes
{
    public class GeraTelefone
    {
        public string Sigla { get; set; }
        [JsonProperty("Ddds")]
        public string[] Ddd { get; set; }
        public void Telefone()
        {
            using (StreamReader sr = new StreamReader("../../../JSONs/dddsPorEstado.json"))
            {
                var json = sr.ReadToEnd();
                var list = new List<GeraTelefone>();
                list = JsonConvert.DeserializeObject<List<GeraTelefone>>(json);

                foreach (var item in list)
                {
                    Console.WriteLine(item.Sigla);
                    for (int i=0; i<item.Ddd.Length; i++)
                    {
                        Console.WriteLine(item.Ddd[i]);
                    }
                }
            }
            
            Random rnd = new Random();

            string telefone;    


        }
    }
}

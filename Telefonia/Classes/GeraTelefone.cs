using Newtonsoft.Json;
using PhoneNumbers;
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
        public string Telefone(string? uf, bool telefoneFixo, bool comTraco, bool comDdd)
        {
            using (StreamReader sr = new StreamReader("../../../JSONs/dddsPorEstado.json"))
            {
                var json = sr.ReadToEnd();
                var list = new List<GeraTelefone>();
                list = JsonConvert.DeserializeObject<List<GeraTelefone>>(json);

                var sigla = uf;
                string ddd = "";
                string telefone = "";
                Random rnd = new Random();

                if(sigla == null)
                {
                    if (telefoneFixo == false)
                    {
                        telefone += GeraDdd();
                        telefone += GeraNumero(telefoneFixo);
                    }
                    else
                    {
                        telefone += GeraDdd();
                        telefone += GeraNumero(telefoneFixo);
                    }

                    string telefoneFormatado = FormataNumero(telefone); ; 
                    
                    return telefoneFormatado;
                }
                else 
                {
                    List<string> ddds = new List<string>();
                    foreach(var item in list)
                    {
                        if (sigla == item.Sigla)
                        {
                            for(int i=0; i<item.Ddd.Length; i++)
                                ddds.Add(item.Ddd[i]);
                        }
                    }

                    telefone += ddds[rnd.Next(ddds.Count())];

                    if (telefoneFixo == false)
                    {

                        telefone += GeraNumero(telefoneFixo);
                        string telefoneFormatado = FormataNumero(telefone);

                        return telefoneFormatado;
                    }
                    else
                    {
                        telefone += GeraNumero(telefoneFixo);
                        string telefoneFormatado = FormataNumero(telefone);

                        return telefoneFormatado;
                    }
                }

            }
        }
        private string FormataNumero(string telefone)
        {
            var phoneUtil = PhoneNumberUtil.GetInstance();
            var numberProto = phoneUtil.Parse(telefone, "BR");
            var telefoneFormatado = phoneUtil.Format(numberProto, PhoneNumberFormat.NATIONAL);

            return telefoneFormatado;
        }
        private string GeraNumero(bool telefoneFixo)
        {
            Random rnd = new Random();
            var telefone = "";

            if (telefoneFixo)
            {
                for (int i = 0; i < 7; i++)
                {
                    if(i == 0)
                    {
                        telefone += rnd.Next(2, 5).ToString();
                    }
                    telefone += rnd.Next(0, 9).ToString();
                }
                return telefone;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        telefone += "9";
                    }

                    telefone += rnd.Next(0, 9).ToString();
                }

                return telefone;
            }
        }

        private string GeraDdd()
        {
            Random rnd = new Random();
            string ddd = "";

            for (int i = 0; i < 2; i++)
            {
                ddd += rnd.Next(0, 9).ToString();
                if (ddd == "25" || ddd == "80")
                {
                    i = 0;
                }
            }

            return ddd;
        }
    }
}

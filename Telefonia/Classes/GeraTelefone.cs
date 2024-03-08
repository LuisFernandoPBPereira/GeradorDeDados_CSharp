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
        //Aqui possuímos os atributos Sigla e Ddd para consumirmos o arquivo JSON
        public string? Sigla { get; set; }
        [JsonProperty("Ddds")]
        public string[]? Ddd { get; set; }

        /*
         * Método Telefone é criado com os parâmetros uf e telefoneFixo
         * 
         * -- uf: recebe a sigla do estado em que deseja que o número seja gerado
         * -- telefoneFixo: recebe um booleano, indicando se o número desejado é
         * um telefone fixo ou não.
        */
        public string Telefone(string? uf, bool telefoneFixo)
        {
            //É usado o StreamReader do System.IO para lermos o arquivo JSON
            using (StreamReader sr = new StreamReader("../../../JSONs/dddsPorEstado.json"))
            {
                //O arquivo é lido
                //E deserializamos em uma lista do tipo GeraTelefone
                var json = sr.ReadToEnd();
                var list = new List<GeraTelefone>();
                list = JsonConvert.DeserializeObject<List<GeraTelefone>>(json);

                var sigla = uf;
                string telefone = "";
                Random rnd = new Random();

                //Se não houver sigla, o DDD é gerado automáticamente
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
                //Caso contrário, comparamos a sigla informada com algum DDD existente no JSON
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

                    //Adicionamos o DDD encontrado, caso tenha mais de um, é escolhido aleatoriamente
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
        /*
         * Aqui temos o Método FormataNumero, que é privado, pois, Classes
         * externas não podem acessá-lo
         * 
         * -- telefone: é informado o número de telefone a ser formatado
        */
        private string FormataNumero(string telefone)
        {
            var telefoneFormatado = "";
            
            //Usamos a biblioteca libphonenumber para formatar no padrão nacional
            var phoneUtil = PhoneNumberUtil.GetInstance();
            var numberProto = phoneUtil.Parse(telefone, "BR");
            telefoneFormatado = phoneUtil.Format(numberProto, PhoneNumberFormat.NATIONAL); 
                
            return telefoneFormatado;
        }
        /*
         * Aqui temos o Método GeraNumero que é privado, responsável por gerar o 
         * número de telefone, verificando se ele é fixo ou não
         * 
         * -- telefoneFixo: é informado por um booleano se o número desejado é fixo
        */
        private string GeraNumero(bool telefoneFixo)
        {
            //Por serem números aletórios, geramos uma variável Random para este método
            Random rnd = new Random();
            var telefone = "";

            if (telefoneFixo)
            {
                for (int i = 0; i < 7; i++)
                {
                    if(i == 0)
                    {
                        //Telefone fixo possui prefixos de 2 a 5
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
                        //Telefone móvel possui prefixo 9
                        telefone += "9";
                    }

                    telefone += rnd.Next(0, 9).ToString();
                }

                return telefone;
            }
        }
        /*
         * Aqui temos o Método GeraDdd que é privado, é responsável por gerar o DDD
         * que não foi informado anteriormente
        */
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
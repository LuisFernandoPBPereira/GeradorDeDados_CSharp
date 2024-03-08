using Telefonia.Classes;

var tel = new GeraTelefone();
//tel.Telefone();

string[] dados = new string[3];

var dadosCliente = new GeraCliente();
dados = dadosCliente.GetCliente();

Cliente cliente = new Cliente(dados[0], dados[1], dados[2], dados[3]);

cliente.Resultado();
using Telefonia.Classes;

//É Criado um array para passarmos os dados do cliente para o construtor
string[] dados = new string[4];
//Um Objeto GeraCliente é instanciado
var dadosCliente = new GeraCliente();

//Recebemos o retorno dos dados de GetCliente
dados = dadosCliente.GetCliente();

//Criamos uma nova instancia de Cliente, passando os dados
Cliente cliente = new Cliente(dados[0], dados[1], dados[2], dados[3]);
//Método Resultado() é chamado
cliente.Resultado();
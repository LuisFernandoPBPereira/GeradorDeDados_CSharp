<h1 align="center">Gerador de Dados</h1>

<br/>

<h2>Sobre:</h2>
<br/>

> [!NOTE]
><p>
>  Esta aplicação retorna dados fictícios de clientes, como: nome, email, data de nascimento e telefone. <br/>
>  Usamos um arquivo JSON com nomes, emails e datas de nascimento, mas os telefones são gerados sem fonte externa.
></p>

<br/>

<h2>Ferramentas utilizadas:</h2>
<ul>
  <li>Visual Studio 2022</li>
  <li>Aplicação de Console (CLI)</li>
  <li>Newtonsoft</li>
  <li>libphonenumber</li>
</ul>

<h2>Como funciona?</h2>
<br/>

> [!NOTE]
> <p>Pelo motivo de este projeto ser relativamente pequeno, não foi seguido algum padrão de arquitetura, mas existe a boa prática de separação de responsabilidades.</p>
<br/>

<h2>Classes:</h2>
<ul>
  <li><h3>Cliente:</h3> Contém os dados do cliente (serão gerados dados de um cliente, com base nesta classe).</li>
  <li><h3>GeraCliente:</h3> Responsável por gerar dados básicos de um cliente (exceto o telefone).</li>
  <li><h3>GeraTelefone:</h3> Responsável por gerar um número de telefone, seja fixo ou móvel, formatado ou não.</li>
</ul>
<br/>

> [!IMPORTANT]
> <p>Ao final, todos os dados são reunidos na Program.cs, instanciando um objeto "Cliente", chamando seu método "DadosGerados".</p>


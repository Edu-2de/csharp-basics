using System;

class Program {
  public static void Main (string[] args) {

    Console.WriteLine ("Criando pessoa 1");
    Pessoa p1;
    p1 = new Pessoa();
    p1.Nome = "João";
    p1.Email = "joao@email.com";
    p1.Telefone = "12345678";
    p1.Endereco = "Rua A";

    p1.MostrarInfo();
    
    Console.WriteLine ("Criando conta1");
    Conta c1;
    c1 = new Conta();
    c1.Numero = 1;
    c1.Agencia = 123;
    c1.Titular = p1;
    
    c1.MostrarInfo();
    c1.Depositar(60000.0);
    c1.MostrarInfo();
    c1.Sacar(22000);
    c1.MostrarInfo();

    Console.WriteLine ("Criando pessoa 2");
    Pessoa p2;
    p2 = new Pessoa("Maria", "maria@email.com", "87654321", "Rua B");
    p2.MostrarInfo();

    Console.WriteLine ("Criando conta2");
    Conta c2;
    c2 = new Conta(456, 123, p2);

    c2.MostrarInfo();
    c2.Depositar(99000.0);
    c2.MostrarInfo();
    c2.Sacar(13500);
    c2.MostrarInfo();


  }
}

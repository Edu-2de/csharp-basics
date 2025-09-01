using System; // Importando o namespace System

class Conta {


  public static int TotalContas { get; private set; } = 0;
  
  public int numero;
  public int Numero{
    get { 
      return this.numero; 
    }
    set{
      numero = value;
    }
  }
  public int Agencia { get; set; }
  public double Saldo { get; private set; }
  public Pessoa Titular { get; set; }

  public Conta(){}

  public Conta(int numero, int agencia, Pessoa titular){
    Numero = numero;
    Agencia = agencia;
    Saldo = 0;
    Titular = titular;
    TotalContas++;
  }

  


  public void MostrarInfo(){
    Console.Write(" Conta: " + this.Numero);
    Console.Write(" Titular: " + this.Titular.Nome);
    Console.Write(" Agencia: " + this.Agencia);
    Console.Write(" Saldo: " + this.Saldo);
    Console.WriteLine("");
    Console.WriteLine("");

  }

  public void Depositar(double valor) {
    this.Saldo = Saldo + valor;

  }

  public void Sacar(double valor) {
    if(Saldo >= valor){
      this.Saldo = Saldo - valor;
      Console.WriteLine("Saque realizado com sucesso");
    }
    else {
      Console.WriteLine("Saldo insuficiente");
    }
  }

  public bool Transferir(double valor, Conta destino){
    if(Saldo >= valor){
      this.Saldo = Saldo - valor;
      destino.Saldo = destino.Saldo + valor;
      Console.WriteLine("Transferencia realizada com sucesso");
      return true;
    }
    else{
      Console.WriteLine("Saldo insuficiente");
      return false;
    }
  }
}

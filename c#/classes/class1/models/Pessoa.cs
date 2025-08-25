using System; 

class Pessoa{
  public string Nome { get; set; }
  public string Email { get; set; }
  public string Telefone { get; set; }
  public string Endereco { get; set; }

  public Pessoa(){}

  public Pessoa(string nome, string email, string telefone, string endereco){
    Nome = nome;
    Email = email;
    Telefone = telefone;
    Endereco = endereco;
  }

  public void MostrarInfo(){
    Console.Write(" Nome: " + Nome);
    Console.Write(" Email: " + Email);
    Console.Write(" Telefone: " + Telefone);
    Console.Write(" Endereco: " + Endereco);
    Console.WriteLine("");
    Console.WriteLine("");

  }
}

class PessoaFisica : Pessoa{
  public string CPF { get; set; }
  public string RG { get; set; }
  public DateOnly DataNascimento { get; set; }
  public string EstadoCivil { get; set; }

  public enum EstadoCivil{
    Solteiro,
    Casado,
    Divorciado,
    Viuvo
  }

  public PessoaFisica(){}

  public PessoaFisica(string nome, string email, string telefone, string endereco,string cpf, string rg, DateOnly datanascimento, string estadoCivil) : base(nome, email, telefone, endereco){
    CPF = cpf;
    RG = rg;
    DataNascimento = datanascimento;
    EstadoCivil = estadoCivil;
  }

  public void MostrarInfo(){
    base.MostrarInfo();
    Console.Write(" CPF: " + CPF);
    Console.Write(" RG: " + RG);
    Console.Write(" Data de Nascimento: " + DataNascimento);
    Console.Write(" Estado Civil: " + EstadoCivil);
    Console.WriteLine("");
    Console.WriteLine("");
  }
}

class PessoaJuridica : Pessoa{
  public string CNPJ { get; set; }

  public PessoaJuridica(){}

  public PessoaJuridica(string nome, string email, string telefone, string endereco, string cnpj) : base(nome, email, telefone, endereco){
    CNPJ = cnpj;
  }

  public void MostrarInfo(){
    base.MostrarInfo();
    Console.Write(" CNPJ: " + CNPJ);
    Console.WriteLine("");
    Console.WriteLine("");
  }
}
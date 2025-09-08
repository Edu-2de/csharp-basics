using System; 

public abstract class Pessoa{
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

  public virtual void MostrarInfo(){
    Console.Write(" Nome: " + Nome);
    Console.Write(" Email: " + Email);
    Console.Write(" Telefone: " + Telefone);
    Console.Write(" Endereco: " + Endereco);
    Console.WriteLine("");
    Console.WriteLine("");
  }
}

class PessoaFisica : Pessoa{
    private string v1;
    private string v2;
    private DateOnly dateOnly;
    private string v3;

    public string CPF { get; set; }
  public string RG { get; set; }
  public DateOnly DataNascimento { get; set; }
  public EstadoCivilEnum EstadoCivil { get; set; } 
  
  public enum EstadoCivilEnum{
    Solteiro,
    Casado,
    Divorciado,
    Viuvo
  }

  public PessoaFisica(string v) {}

  public PessoaFisica(string nome, string email, string telefone, string endereco, string cpf, string rg, DateOnly datanascimento, EstadoCivilEnum estadoCivil) 
    : base(nome, email, telefone, endereco){
    CPF = cpf;
    RG = rg;
    DataNascimento = datanascimento;
    EstadoCivil = estadoCivil;
  }

    public PessoaFisica(string nome, string email, string telefone, string endereco, string v1, string v2, DateOnly dateOnly, string v3) : base(nome, email, telefone, endereco)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.dateOnly = dateOnly;
        this.v3 = v3;
    }

    public override void MostrarInfo(){
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
  public DateOnly DataAbertura { get; set; }

  public PessoaJuridica(){}

  public PessoaJuridica(string nome, string email, string telefone, string endereco, string cnpj, DateOnly dataAbertura) 
    : base(nome, email, telefone, endereco){
    CNPJ = cnpj;
    DataAbertura = dataAbertura;
  }

  public override void MostrarInfo(){
    base.MostrarInfo();
    Console.Write(" CNPJ: " + CNPJ);
    Console.Write(" Data de Abertura: " + DataAbertura);
    Console.WriteLine("");
    Console.WriteLine("");
  }
}

namespace Biblioteca {
    public abstract class Pessoa {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Endereco {get;set;}
        public string Telefone {get;set;}
        public string Email{get;set;}
    }


    public class Leitor:Pessoa{
        public DateTime DataNascimento{get;set;}
    }
}

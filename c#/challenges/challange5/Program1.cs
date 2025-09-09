namespace Biblioteca {
    public abstract class Pessoa {
        public static int NumeroDePessoas { get; set; } = 0;
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Endereco {get;set;}
        public string Telefone {get;set;}
        public string Email{get;set;}
    }


    public class Leitor:Pessoa{
        public DateTime DataNascimento{get;set;}

        public Leitor(DateTime dataNascimento, int id, string nome, string email, string endereco, string telefone, ){
            Id = ++NumeroDePessoas;
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }
    }
}

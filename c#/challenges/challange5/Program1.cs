namespace Biblioteca {
    public abstract class Pessoa {
        public static int NumeroDePessoas { get; set; } = 0;
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Endereco {get;set;}
        public string Telefone {get;set;}
        public string Email{get;set;}
    }

    public class Livro{
        public static int NumeroDeLivros { get; set; } = 0;
        public int Id{get;set;}
        public string Titulo {get; set;}
        public string Autor {get;set;}
        public int AnoPublicacao{get;set;}
        public string Genero{get;set;}
        public bool Disponivel  {get; set;}
    }

    public class Emprestimo{
        public Livro Livro{get;set;}
        public Leitor Leitor{get; set;}
        public DateTime DataEmprestimo{get;set;}
        public DateTime? DataRetorno{get;set;}
    }


    public class Leitor:Pessoa{
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        public DateTime DataNascimento{get;set;}

        public Leitor(DateTime dataNascimento, int id, string nome, string email, string endereco, string telefone){
            Id = ++NumeroDePessoas;
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public bool EmprestarLivro(Livro livro){
            if (Emprestimos.Count >= 5 || !livro.Disponivel)
                return false;

            var emprestimo = new Emprestimo
            {
                Livro = livro,
                Leitor = this,
                DataEmprestimo = DateTime.Now,
                DataRetorno = null
            };
            Emprestimos.Add(emprestimo);
            livro.Disponivel = false;
            return true;
        }
    }

    public class Funcionario:Pessoa{
        public string Cargo{get;set;}
        public DateTime DataAdmisso{get;set;}

        public Funcionario(string cargo, DateTime dataAdmisso, int id, string nome, string email, string endereco, string telefone){
            Id = ++NumeroDePessoas;
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
            Cargo = cargo;
            DataAdmisso = dataAdmisso;

        }
    }

   
}

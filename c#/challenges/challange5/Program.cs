namespace Bank
{
  public static class Aux
  {
    public static int CalculateAge(DateTime data)
    {
      var today = DateTime.Today;
      int age = today.Year - data.Year;
      if (data.Date > today.AddYears(-age)) age--;
      return age;
    }

    public static AgeRange(int age)
    {
      if (age <= 11) return "kid";
      else if (age <= 21) return "young";
      else if (age <= 59) return "adult";
      else return "old";
    }
  }

  public abstract class People
  {
    public static int NumberOfPeoples { get; set; } = 0;
    public int Id { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
  }

  public class Individual : People
  {
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public DateTime DateBorn { get; set; }
    public string AgeRange { get { return Aux.CalculateAge(age); } }
    public double Income { get; set; }

    public Individual(string name, string lastName, string rg, string cpf, DateTime dateBorn, double income, string address, string phone, string email)
    {
      Id = ++NumberOfPeoples;
      Name = name;
      LastName = lastName;
      Rg = rg;
      Cpf = cpf;
      DateBorn = dateBorn;
      Income = income;
      Address = address;
      Phone = phone;
      Email = email;
    }
  }

  public class LegalEntity : People
  {
    public List<Individual> Partners { get; set; } = new List<Individual>();
    public int Cnpj { get; set; }
    public string CorporateName { get; set; }
    public string FantasyName { get; set; }
    public int StateRegistration { get; set; }
    public DateTime OpeningDate { get; set; }
    public int Age { get { return Aux.CalculateAge(OpeningDate); } }
    public double Revenue { get; set; }

    public LegalEntity(List<Individual> partners, int cnpj, string corporateName, string fantasyName, int stateRegistration, DateTime openingDate, double revenue, string address, string phone, string email)
    {
      Id = ++NumberOfPeoples;
      Partners = partners;
      Cnpj = cnpj;
      CorporateName = corporateName;
      FantasyName = fantasyName;
      StateRegistration = stateRegistration;
      OpeningDate = openingDate;
      Revenue = revenue;
      Address = address;
      Phone = phone;
      Email = email;
    }
  }

  public abstract class Account
  {
    public People Titular { get; set; }
    public long Number { get; set; }
    public int Agency { get; set; }
    public double Balance { get; protected set; }
    public double FeeWithdrawal { get; set; }

    public Account(Pessoa titular, long number, int agency, double feeWithdrawal)
    {
        Titular = titular;
        Number = number;
        Agency = agency;
        Balance = 0.0;
        FeeWithdrawal = feeWithdrawal;
    }

    public abstract bool Sacar(double valor);
    public double ConsultarSaldo() => Saldo;
    public virtual bool Transferir(Conta conta, double valor)
    {
        if (Sacar(valor))
        {
            conta.Depositar(valor);
            return true;
        }
        return false;
    }

    public abstract void Depositar(double valor);
  }

}

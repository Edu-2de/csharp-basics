using System;
using System.Collections.Generic;

namespace Bank
{
    public static class Helper
    {
        public static int CalculateAge(DateTime date)
        {
            var today = DateTime.Today;
            int age = today.Year - date.Year;
            if (date.Date > today.AddYears(-age)) age--;
            return age;
        }

        public static string AgeGroup(int age)
        {
            if (age <= 11) return "child";
            else if (age <= 21) return "young";
            else if (age <= 59) return "adult";
            else return "elderly";
        }
    }

    public abstract class Person
    {
        public static int NumberOfPeople { get; set; } = 0;
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class Individual : Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get { return Helper.CalculateAge(BirthDate); } }
        public string AgeGroup { get { return Helper.AgeGroup(Age); } }
        public double Income { get; set; }

        public Individual(string firstName, string lastName, string rg, string cpf, DateTime birthDate, double income,
            string address, string phone, string email)
        {
            Id = ++NumberOfPeople;
            FirstName = firstName;
            LastName = lastName;
            Rg = rg;
            Cpf = cpf;
            BirthDate = birthDate;
            Income = income;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }

    public class LegalEntity : Person
    {
        public List<Individual> Partners { get; set; } = new List<Individual>();
        public int Cnpj { get; set; }
        public string CorporateName { get; set; }
        public string TradeName { get; set; }
        public int StateRegistration { get; set; }
        public DateTime OpeningDate { get; set; }
        public int Age { get { return Helper.CalculateAge(OpeningDate); } }
        public double Revenue { get; set; }

        public LegalEntity(List<Individual> partners, int cnpj, string corporateName, string tradeName,
            int stateRegistration, DateTime openingDate, double revenue,
            string address, string phone, string email)
        {
            Id = ++NumberOfPeople;
            Partners = partners;
            Cnpj = cnpj;
            CorporateName = corporateName;
            TradeName = tradeName;
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
        public Person Holder { get; set; }
        public long Number { get; set; }
        public int Branch { get; set; }
        public double Balance { get; protected set; }
        public double WithdrawFee { get; set; }

        public Account(Person holder, long number, int branch, double withdrawFee)
        {
            Holder = holder;
            Number = number;
            Branch = branch;
            Balance = 0.0;
            WithdrawFee = withdrawFee;
        }

        public abstract bool Withdraw(double amount);
        public double GetBalance() => Balance;
        public virtual bool Transfer(Account account, double amount)
        {
            if (Withdraw(amount))
            {
                account.Deposit(amount);
                return true;
            }
            return false;
        }

        public abstract void Deposit(double amount);
    }

    public interface IDepositable
    {
        void Deposit(double amount);
    }

    public class SavingsAccount : Account, IDepositable
    {
        public SavingsAccount(Person holder, long number, int branch, double withdrawFee)
            : base(holder, number, branch, withdrawFee) { }

        public override bool Withdraw(double amount)
        {
            if (Balance - amount - WithdrawFee >= 0)
            {
                Balance -= (amount + WithdrawFee);
                return true;
            }
            return false;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }
    }

    public class PayrollAccount : Account
    {
        public PayrollAccount(Person holder, long number, int branch)
            : base(holder, number, branch, 0) { }

        public override bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override bool Transfer(Account account, double amount)
        {
            if (Holder == account.Holder && Withdraw(amount))
            {
                account.Deposit(amount);
                return true;
            }
            return false;
        }

        public override void Deposit(double amount) { Balance += amount; }
    }

    public class CheckingAccount : Account, IDepositable
    {
        public string Type { get; private set; }
        public double Limit { get; private set; }
        public double LimitFee { get; private set; }

        public CheckingAccount(Person holder, long number, int branch, string type, double income)
            : base(holder, number, branch, 0)
        {
            Type = type.ToUpper();
            if (Type == "SPECIAL")
            {
                if (income <= 5000)
                    throw new ArgumentException("Insufficient revenue/income for special account.");
                Limit = income * 2.5;
                LimitFee = 0.02;
            }
            else
            {
                Limit = income * 1.5;
                LimitFee = 0.05;
            }
        }

        public override bool Withdraw(double amount)
        {
            if (Balance - amount >= -Limit)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Pay(string barCode)
        {
        }

        public void Loan(double amount)
        {
            if (Balance + amount <= Limit)
                Balance += amount;
        }
    }
}

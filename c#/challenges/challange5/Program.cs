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

}
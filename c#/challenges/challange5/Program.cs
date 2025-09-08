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
  }
}
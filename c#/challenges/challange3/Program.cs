
public abstract class Pet
{
  public string Name { get; set; }
  public int Age { get; set; }
  public string OwnerName { get; set; }
}

public class Dog : Pet
{
  public string Bread { get; set; }
  public Bark()
  {
    return Console.ReadLine("Au AU aU Au");
  }

}

public class Cat : Pet
{
  public string Color { get; set; }
  public Meow()
  {
    return Console.ReadLine("Meow mEow MEoW");
  }

}

class Program
{
  static void Main()
  {
    var pets = new List<Pet>();
    bool exit = false;

    while (!exit)
    {
      Console.Clear();
      Console.WriteLine("1 - Add new Dog");
      Console.WriteLine("2 - Add new Cat");
      Console.WriteLine("3 - List all pets");
      Console.WriteLine("4 - Make a pet sound (choose pet and call Bark/Meow)");

      Console.WriteLine("Choose an option:");
      string option = Console.ReadLine();

      switch (option)
      {
        case "1":
          Dog d = new();
          Console.WriteLine("Enter dog's name:");
          d.Name = Console.ReadLine();

          Console.WriteLine("Enter dog's age:");
          d.Age = int.Parse(Console.ReadLine());

          Console.WriteLine("Enter dog's owner name:");
          d.OwnerName = Console.ReadLine();

          Console.WriteLine("Enter dog's breed:");
          d.Breed = Console.ReadLine();

          pets.Add(d);
          break;
              
      }
    }
  }
  
}

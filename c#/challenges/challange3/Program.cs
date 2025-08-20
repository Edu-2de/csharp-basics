
public abstract class Pet
{
  public string Name { get; set; }
  public int Age { get; set; }
  public string OwnerName { get; set; }
}

public abstract class Dog : Pet
{
  public string Bread { get; set; }
  public Bark()
  {
    return Console.ReadLine("Au AU aU Au");
  }

}

public abstract class Cat : Pet
{
  public string Color { get; set; }
  public Meow ()
  {
    return Console.ReadLine("Meow mEow MEoW");
  }

}
using System;
using System.Collections.Generic;

public abstract class Pet
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? OwnerName { get; set; }
}

public class Dog : Pet
{
    public string? Breed { get; set; }
    public static void Bark()
    {
        Console.WriteLine("Au AU aU Au");
    }
}

public class Cat : Pet
{
    public string? Color { get; set; }
    public static void Meow()
    {
        Console.WriteLine("Meow mEow MEoW");
    }
}

public class Program
{
    public static void Main()
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
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Choose an option:");
            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    Dog d = new();
                    Console.WriteLine("Enter dog's name:");
                    d.Name = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter dog's age:");
                    string? dogAgeInput = Console.ReadLine();
                    if (!int.TryParse(dogAgeInput, out int dogAge))
                    {
                        Console.WriteLine("Invalid age entered. Setting age to 0.");
                        dogAge = 0;
                    }
                    d.Age = dogAge;

                    Console.WriteLine("Enter dog's owner name:");
                    d.OwnerName = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter dog's breed:");
                    d.Breed = Console.ReadLine() ?? string.Empty;

                    pets.Add(d);
                    break;

                case "2":
                    Cat c = new();
                    Console.WriteLine("Enter cat's name:");
                    string? catNameInput = Console.ReadLine();
                    c.Name = catNameInput ?? string.Empty;

                    Console.WriteLine("Enter cat's age:");
                    string? catAgeInput = Console.ReadLine();
                    if (!int.TryParse(catAgeInput, out int catAge))
                    {
                        Console.WriteLine("Invalid age entered. Setting age to 0.");
                        catAge = 0;
                    }
                    c.Age = catAge;

                    Console.WriteLine("Enter cat's owner name:");
                    c.OwnerName = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter cat's color:");
                    c.Color = Console.ReadLine() ?? string.Empty;

                    pets.Add(c);
                    break;

                case "3":
                    if (pets.Count == 0)
                    {
                        Console.WriteLine("No pets registered.");
                    }
                    else
                    {
                        Console.WriteLine("Registered pets:");
                        foreach (var pet in pets)
                        {
                            Console.WriteLine($"Type: {pet.GetType().Name}");
                            Console.WriteLine($"Name: {pet.Name}");
                            Console.WriteLine($"Age: {pet.Age}");
                            Console.WriteLine($"Owner: {pet.OwnerName}");

                            if (pet is Dog dog)
                                Console.WriteLine($"Breed: {dog.Breed}");
                            else if (pet is Cat cat)
                                Console.WriteLine($"Color: {cat.Color}");

                            Console.WriteLine("-------------------");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("Enter the pet's name to make a sound:");
                    string searchName = Console.ReadLine() ?? string.Empty;
                    bool found = false;

                    foreach (var pet in pets)
                    {
                        if (!string.IsNullOrEmpty(pet.Name) && pet.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            if (pet is Dog dog)
                            {
                                Console.WriteLine("Dog sound:");
                Dog.Bark();
                            }
                            else if (pet is Cat cat)
                            {
                                Console.WriteLine("Cat sound:");
                Cat.Meow();
                            }
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Pet not found.");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

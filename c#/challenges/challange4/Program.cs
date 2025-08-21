public abstract class MediaItem
{
  public string? Title { get; set; }
  public int Year { get; set; }
  public string? AuthorOrDirector { get; set; }
}

public class Book : MediaItem
{
  public int NumberOfPages { get; set; }

  public static void ShowSummary()
  {
    Console.WriteLine($"Title: {Title}, Number of pages: {NumberOfPages}");
  }
}

public class Movie : MediaItem
{
  public int Duration { get; set; }

  public static void PlayTrailer()
  {
    Console.WriteLine("Trailer played");
  }
}

public class Music : MediaItem
{
  public string? Genre { get; set; }

  public static void PlaySample()
  {
    Console.WriteLine("Music played");
  }
}

public class Program
{
  public static void Main()
  {
    var mediaItems = new List<MediaItem>();
    bool exit = false;

    while (!exit)
    {
      Console.Clear();
      Console.WriteLine("1 - Add new Book");
      Console.WriteLine("2 - Add new Movie");
      Console.WriteLine("3 - Add new Music");
      Console.WriteLine("4 - List all media items");
      Console.WriteLine("5 - Show details and play");
      Console.WriteLine("6 - Exit");
      Console.WriteLine("Choose an option:");
      string option = Console.ReadLine() ?? string.Empty;

      switch (option)
      {
        case "1":
          MediaItem m = new();
          Console.WriteLine("Enter book's title:");
          m.Name = Console.ReadLine() ?? string.Empty;

          Console.WriteLine("Enter book's year:");
          string? bookYearInput = Console.ReadLine();
          if (!int.TryParse(bookYearInput, out int bookYear))
          {
            Console.WriteLine("Invalid age entered. Setting age to 0.");
            bookYear = 0;
          }
          m.Year = bookYear;
          

          
      }
    }
  }
}
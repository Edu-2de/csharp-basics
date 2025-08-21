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
          Book m = new();
          Console.WriteLine("Enter book's title:");
          m.Name = Console.ReadLine() ?? string.Empty;

          Console.WriteLine("Enter book's year:");
          string? bookYearInput = Console.ReadLine();
          if (!int.TryParse(bookYearInput, out int bookYear))
          {
            Console.WriteLine("Invalid value entered. Setting value to 0.");
            bookYear = 0;
          }
          m.Year = bookYear;

          Console.WriteLine("Enter book's author:");
          m.AuthorOrDirector = Console.Readline() ?? string.Empty;

          Console.WriteLine("Enter book's number of pages:");
          string? bookNumberInput = Console.Readline();
          if (!int.TryParse(bookNumberInput, out int bookNumber))
          {
            Console.WriteLine("Invalid value entered. Setting value to 0.");
            bookNumber = 0;
          }
          m.NumberOfPages = bookNumber;

          mediaItems.Add(m);
          break;

        case "2":
          Movie m = new();
          Console.WriteLine("Enter movie's title:");
          m.Name = Console.ReadLine() ?? string.Empty;

          Console.WriteLine("Enter movie's year:");
          string? movieYearInput = Console.ReadLine();
          if (!int.TryParse(movieYearInput, out int movieYear))
          {
            Console.WriteLine("Invalid value entered. Setting value to 0.");
            movieYear = 0;
          }
          m.Year = movieYear;

          Console.WriteLine("Enter movie's director:");
          m.AuthorOrDirector = Console.Readline() ?? string.Empty;

          Console.WriteLine("Enter movie's duration:");
          string? movieDurationInput = Console.Readline();
          if (!int.TryParse(movieDurationInput, out int movieDuration))
          {
            Console.WriteLine("Invalid value entered. Setting value to 0.");
            movieDuration = 0;
          }
          m.Duration = movieDuration;

          mediaItems.Add(m);
          break;

        case "3":
          Music m = new();
          Console.WriteLine("Enter music's title:");
          m.Name = Console.ReadLine() ?? string.Empty;

          Console.WriteLine("Enter music's year:");
          string? musicYearInput = Console.ReadLine();
          if (!int.TryParse(musicYearInput, out int musicYear))
          {
            Console.WriteLine("Invalid value entered. Setting value to 0.");
            musicYear = 0;
          }
          m.Year = musicYear;

          Console.WriteLine("Enter music's director:");
          m.AuthorOrDirector = Console.Readline() ?? string.Empty;

          Console.WriteLine("Enter music's genre:");
          m.Genre = Console.Readline() ?? string.Empty;

          mediaItems.Add(m);
          break;
          
        case "4":
          if (mediaItems.Count == 0)
          {
            Console.WriteLine("No media registered.");
          }
          else
          {
            Console.WriteLine("Registered medias:");
            foreach (var media in mediaItems)
            {
              Console.WriteLine($"Title: {media.Title}");
              Console.WriteLine($"Year: {media.Year}");
              Console.WriteLine($"AuthorOrDirector: {media.AuthorOrDirector}");

              if (media is Book book)
              {
                Console.WriteLine($"Number of pages: {media.NumberOfPages}");
              }
              else if (media is Movie movie)
              {
                Console.WriteLine($"Duration : {media.Duration}");
              }
              else if (media is Music music)
              {
                Console.WriteLine($"Genre : {media.Genre}");
              }

              Console.WriteLine("-------------------");
            }
          }
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
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
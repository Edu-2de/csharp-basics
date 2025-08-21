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
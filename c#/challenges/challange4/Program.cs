using System;
using System.Collections.Generic;

public abstract class MediaItem
{
    public string? Title { get; set; }
    public int Year { get; set; }
    public string? AuthorOrDirector { get; set; }

    public abstract void ShowDetailsAndPlay();
}

public class Book : MediaItem
{
    public int NumberOfPages { get; set; }

    public override void ShowDetailsAndPlay()
    {
        Console.WriteLine($"Book: {Title} ({Year}) by {AuthorOrDirector}");
        Console.WriteLine($"Number of pages: {NumberOfPages}");
        Console.WriteLine("Showing summary...");
    }
}

public class Movie : MediaItem
{
    public int Duration { get; set; }

    public override void ShowDetailsAndPlay()
    {
        Console.WriteLine($"Movie: {Title} ({Year}) directed by {AuthorOrDirector}");
        Console.WriteLine($"Duration: {Duration} minutes");
        Console.WriteLine("Trailer played!");
    }
}

public class Music : MediaItem
{
    public string? Genre { get; set; }

    public override void ShowDetailsAndPlay()
    {
        Console.WriteLine($"Music: {Title} ({Year}) by {AuthorOrDirector}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine("Music sample played!");
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
                    Book book = new();
                    Console.WriteLine("Enter book's title:");
                    book.Title = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter book's year:");
                    string? bookYearInput = Console.ReadLine();
                    if (!int.TryParse(bookYearInput, out int bookYear))
                    {
                        Console.WriteLine("Invalid value entered. Setting value to 0.");
                        bookYear = 0;
                    }
                    book.Year = bookYear;

                    Console.WriteLine("Enter book's author:");
                    book.AuthorOrDirector = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter book's number of pages:");
                    string? bookNumberInput = Console.ReadLine();
                    if (!int.TryParse(bookNumberInput, out int bookNumber))
                    {
                        Console.WriteLine("Invalid value entered. Setting value to 0.");
                        bookNumber = 0;
                    }
                    book.NumberOfPages = bookNumber;

                    mediaItems.Add(book);
                    break;

                case "2":
                    Movie movie = new();
                    Console.WriteLine("Enter movie's title:");
                    movie.Title = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter movie's year:");
                    string? movieYearInput = Console.ReadLine();
                    if (!int.TryParse(movieYearInput, out int movieYear))
                    {
                        Console.WriteLine("Invalid value entered. Setting value to 0.");
                        movieYear = 0;
                    }
                    movie.Year = movieYear;

                    Console.WriteLine("Enter movie's director:");
                    movie.AuthorOrDirector = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter movie's duration (minutes):");
                    string? movieDurationInput = Console.ReadLine();
                    if (!int.TryParse(movieDurationInput, out int movieDuration))
                    {
                        Console.WriteLine("Invalid value entered. Setting value to 0.");
                        movieDuration = 0;
                    }
                    movie.Duration = movieDuration;

                    mediaItems.Add(movie);
                    break;

                case "3":
                    Music music = new();
                    Console.WriteLine("Enter music's title:");
                    music.Title  = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter music's year:");
                    string? musicYearInput = Console.ReadLine();
                    if (!int.TryParse(musicYearInput, out int musicYear))
                    {
                        Console.WriteLine("Invalid value entered. Setting value to 0.");
                        musicYear = 0;
                    }
                    music.Year = musicYear;

                    Console.WriteLine("Enter music's artist:");
                    music.AuthorOrDirector = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter music's genre:");
                    music.Genre = Console.ReadLine() ?? string.Empty;

                    mediaItems.Add(music);
                    break;

                case "4":
                    if (mediaItems.Count == 0)
                    {
                        Console.WriteLine("No media registered.");
                    }
                    else
                    {
                        Console.WriteLine("Registered media items:");
                        foreach (var media in mediaItems)
                        {
                            Console.WriteLine($"Type: {media.GetType().Name}");
                            Console.WriteLine($"Title: {media.Title}");
                            Console.WriteLine($"Year: {media.Year}");
                            Console.WriteLine($"Author/Director: {media.AuthorOrDirector}");

                            if (media is Book bookItem)
                                Console.WriteLine($"Number of pages: {bookItem.NumberOfPages}");
                            else if (media is Movie movieItem)
                                Console.WriteLine($"Duration: {movieItem.Duration} minutes");
                            else if (media is Music musicItem)
                                Console.WriteLine($"Genre: {musicItem.Genre}");

                            Console.WriteLine("-------------------");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.WriteLine("Enter the media's title:");
                    string searchTitle = Console.ReadLine() ?? string.Empty;
                    bool found = false;

                    foreach (var media in mediaItems)
                    {
                        if (!string.IsNullOrEmpty(media.Title) && media.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            media.ShowDetailsAndPlay();
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Media not found.");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "6":
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
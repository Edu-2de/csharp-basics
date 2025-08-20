using System;

public class Contact
{
    private string Name { get; set; }
    private string Phone { get; set; }

    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public string GetName() => Name;
    public string GetPhone() => Phone;
}

public abstract class Message
{
    private Contact Recipient { get; set; }
    private string SendTime { get; set; }
    private string Content { get; set; }

    public Message(Contact recipient, string sendTime, string content)
    {
        Recipient = recipient;
        SendTime = sendTime;
        Content = content;
    }

    public override string ToString()
    {
        return $"Message to {Recipient.GetName()} ({Recipient.GetPhone()}):\n" +
               $"Sent at: {SendTime}\n" +
               $"Content: {Content}";
    }
}

public class TextMessage : Message
{
    private int CharacterCount { get; set; }

    public TextMessage(Contact recipient, string sendTime, string content)
        : base(recipient, sendTime, content)
    {
        CharacterCount = content.Length;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCharacter count: {CharacterCount}";
    }
}

public class AudioMessage : Message
{
    private int Duration { get; set; }

    public AudioMessage(Contact recipient, string sendTime, string content, int duration)
        : base(recipient, sendTime, content)
    {
        Duration = duration;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nDuration: {Duration} seconds";
    }
}

public class PhotoMessage : Message
{
    private int Size { get; set; }

    public PhotoMessage(Contact recipient, string sendTime, string content, int size)
        : base(recipient, sendTime, content)
    {
        Size = size;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nSize: {Size} KB";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Send Text Message");
            Console.WriteLine("2 - Send Audio Message");
            Console.WriteLine("3 - Send Photo Message");
            Console.WriteLine("4 - Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter recipient's name:");
                    string nameText = Console.ReadLine();
                    Console.WriteLine("Enter recipient's phone:");
                    string phoneText = Console.ReadLine();
                    Console.WriteLine("Enter send time:");
                    string timeText = Console.ReadLine();
                    Console.WriteLine("Enter message content:");
                    string contentText = Console.ReadLine();

                    var recipientText = new Contact(nameText, phoneText);
                    var textMessage = new TextMessage(recipientText, timeText, contentText);

                    Console.WriteLine(textMessage.ToString());
                    break;

                case "2":
                    Console.WriteLine("Enter recipient's name:");
                    string nameAudio = Console.ReadLine();
                    Console.WriteLine("Enter recipient's phone:");
                    string phoneAudio = Console.ReadLine();
                    Console.WriteLine("Enter send time:");
                    string timeAudio = Console.ReadLine();
                    Console.WriteLine("Enter message content:");
                    string contentAudio = Console.ReadLine();
                    Console.WriteLine("Enter audio duration (in seconds):");
                    int durationAudio = int.Parse(Console.ReadLine());

                    var recipientAudio = new Contact(nameAudio, phoneAudio);
                    var audioMessage = new AudioMessage(recipientAudio, timeAudio, contentAudio, durationAudio);

                    Console.WriteLine(audioMessage.ToString());
                    break;

                case "3":
                    Console.WriteLine("Enter recipient's name:");
                    string namePhoto = Console.ReadLine();
                    Console.WriteLine("Enter recipient's phone:");
                    string phonePhoto = Console.ReadLine();
                    Console.WriteLine("Enter send time:");
                    string timePhoto = Console.ReadLine();
                    Console.WriteLine("Enter message content:");
                    string contentPhoto = Console.ReadLine();
                    Console.WriteLine("Enter photo size (in KB):");
                    int sizePhoto = int.Parse(Console.ReadLine());

                    var recipientPhoto = new Contact(namePhoto, phonePhoto);
                    var photoMessage = new PhotoMessage(recipientPhoto, timePhoto, contentPhoto, sizePhoto);

                    Console.WriteLine(photoMessage.ToString());
                    break;

                case "4":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
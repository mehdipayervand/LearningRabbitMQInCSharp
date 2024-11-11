namespace RequestDirectMessage;

class Program
{
    static async Task Main(string[] args)
    {
        var directMessage = new DirectMessage();

       await directMessage.SendMessage();

       Console.WriteLine("press any key to end!");
       Console.ReadKey();
    }
}
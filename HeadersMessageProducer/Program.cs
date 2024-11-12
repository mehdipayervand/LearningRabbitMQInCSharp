namespace HeadersMessageProducer;

class Program
{
    static async Task Main(string[] args)
    {
        Headersmessages headersmessages = new Headersmessages();
        await headersmessages.SendMessage();
        Console.ReadLine();
    }
}
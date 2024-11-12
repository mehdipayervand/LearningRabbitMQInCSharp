namespace FanoutMessageProducer;

class Program
{
    static async Task Main(string[] args)
    {
        Fanoutmessages fanoutmessages = new Fanoutmessages();
        await fanoutmessages.SendMessage();
        Console.ReadLine();
    }
}
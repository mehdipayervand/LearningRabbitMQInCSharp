namespace TopicMessageProducer;

class Program
{
    static async Task Main(string[] args)
    {
        TopicMessages topicMessages = new TopicMessages();
        //await topicMessages.SendBombayMessage();
        await topicMessages.SendDehliMessage();

        Console.ReadKey();
    }
}
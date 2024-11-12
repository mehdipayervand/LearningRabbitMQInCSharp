using RabbitMQ.Client;

namespace TopicMessageConsumer;

class Program
{
    private const string UserName = "guest";
    private const string Password = "guest";
    private const string HostName = "localhost";

    static async Task Main(string[] args)
    {
        ConnectionFactory connectionFactory = new
            ConnectionFactory
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password,
            };
        var connection = await connectionFactory.CreateConnectionAsync();
        IChannel channel = await connection.CreateChannelAsync();

        // accept only one unack-ed message at a time
        // uint prefetchSize, ushort prefetchCount, bool global
        await channel.BasicQosAsync(0, 1, false);
        MessageReceiver messageReceiver = new MessageReceiver(channel);
        //await channel.BasicConsumeAsync("topic.bombay.queue", false, messageReceiver);
        await channel.BasicConsumeAsync("topic.delhi.queue", false, messageReceiver);
        
        Console.ReadLine();
    }
}
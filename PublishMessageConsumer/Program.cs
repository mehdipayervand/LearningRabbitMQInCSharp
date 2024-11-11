using RabbitMQ.Client;

namespace PublishMessageConsumer;

class Program
{
    static async Task Main(string[] args)
    {
        string UserName = "guest";
        string Password = "guest";
        string HostName = "localhost";

        var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
        {
            UserName = UserName,
            Password = Password,
            HostName = HostName
        };

        var connection = await connectionFactory.CreateConnectionAsync();
        IChannel channel = await connection.CreateChannelAsync();

        // accept only one unack-ed message at a time
        // uint prefetchSize, ushort prefetchCount, bool global
        await channel.BasicQosAsync(0, 1, false);
        
        MessageReceiver messageReceiver = new MessageReceiver(channel);
        await channel.BasicConsumeAsync("demoQueue", false, messageReceiver);

        Console.ReadLine();
    }
}
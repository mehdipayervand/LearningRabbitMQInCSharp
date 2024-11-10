using System.Text;
using RabbitMQ.Client;

namespace RabbitMQConsumer;

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

    public class MessageReceiver : RabbitMQ.Client.AsyncDefaultBasicConsumer
    {
        private IChannel _channel;

        public MessageReceiver(IChannel channel) : base(channel)
        {
            _channel = channel;
        }

        public override async Task HandleBasicDeliverAsync(string consumerTag, ulong deliveryTag, bool redelivered,
            string exchange,
            string routingKey, IReadOnlyBasicProperties properties, ReadOnlyMemory<byte> body,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine("Consuming Message");
            Console.WriteLine(string.Concat("Message received from the exchange", exchange));
            Console.WriteLine(string.Concat("Consumer tag:", consumerTag));
            Console.WriteLine(string.Concat("Delivery tag:", deliveryTag));
            Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body.Span)));
            await _channel.BasicAckAsync(deliveryTag, false, cancellationToken);
        }
    }
}
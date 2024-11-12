using System.Text;
using RabbitMQ.Client;

namespace HeadersMessageConsumer;

public class MessageReceiver : AsyncDefaultBasicConsumer
{
    private IChannel _channel;
    public MessageReceiver(IChannel channel) : base(channel)
    {
        _channel = channel;
    }

    public override async Task HandleBasicDeliverAsync(
        string consumerTag,
        ulong deliveryTag,
        bool redelivered,
        string exchange,
        string routingKey,
        IReadOnlyBasicProperties properties,
        ReadOnlyMemory<byte> body,
        CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Consuming headers Message");
        Console.WriteLine(string.Concat("Consuming received from exchange:", exchange));
        Console.WriteLine(string.Concat("Consumer tag:", consumerTag));
        Console.WriteLine(string.Concat("Delivery tag:", deliveryTag));
        Console.WriteLine(string.Concat("Routing tag: ",routingKey));
        Console.WriteLine(string.Concat("Message: ",Encoding.UTF8.GetString(body.Span)));
        
       await _channel.BasicAckAsync(deliveryTag, false, cancellationToken);
        
    }
    
}
using System.Text;
using RabbitMQ.Client;

namespace FanoutMessageProducer;

public class Fanoutmessages
{
    private const string UserName = "guest";
    private const string Password = "guest";
    private const string HostName = "localhost";

    public async Task SendMessage()
    {
        //Main entry point to the RabbitMQ .NET AMQP client
        var connectionFactory = new ConnectionFactory()
        {
            UserName = UserName,
            Password = Password,
            HostName = HostName
        };
        var connection = await connectionFactory.CreateConnectionAsync();
        var model = await connection.CreateChannelAsync();
        byte[] messagebuffer = Encoding.Default.GetBytes("Message is of fanout Exchange type");
        await model.BasicPublishAsync("fanout.exchange", "Message.Bombay.Email", messagebuffer);
        Console.WriteLine("Message Sent From :-fanout.exchange");
        Console.WriteLine("Routing Key :- Routing key is Not required for fanout exchange");
        Console.WriteLine("Message Sent");
    }
    

}
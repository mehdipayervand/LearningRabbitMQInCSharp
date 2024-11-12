using System.Text;
using RabbitMQ.Client;

namespace TopicMessageProducer;

public class TopicMessages
{
    private const string UserName = "guest";
    private const string Password = "guest";
    private const string HostName = "localhost";

    public async Task SendBombayMessage()
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
        byte[] messagebuffer = Encoding.Default.GetBytes("Message from Topic Exchange‘Bombay’ ");
        await model.BasicPublishAsync("topic.exchange", "Message.Bombay.Email", messagebuffer);
        Console.WriteLine("Message Sent From :-topic.exchange");
        Console.WriteLine("Routing Key :-Message.Bombay.Email");
        Console.WriteLine("Message Sent");
    }
    
    public async Task SendDehliMessage()
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
        byte[] messagebuffer = Encoding.Default.GetBytes("Message from Topic Exchange‘Dehli’ ");
        await model.BasicPublishAsync("topic.exchange", "Delhi.TicketBooking", messagebuffer);
        Console.WriteLine("Message Sent From :-topic.exchange");
        Console.WriteLine("Routing Key :-Delhi.TicketBooking");
        Console.WriteLine("Message Sent");
    }
}
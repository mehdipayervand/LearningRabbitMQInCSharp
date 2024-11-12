using System.Text;
using RabbitMQ.Client;

namespace HeadersMessageProducer;

public class Headersmessages
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
        var channel = await connection.CreateChannelAsync();
        
        var headers = new Dictionary<string, object>
        {
            { "format", "pdf" }
        };

        var properties = new BasicProperties
        {
            Headers = headers,
            Persistent = true // Ensures message persistence
        };
        
        
        byte[] messagebuffer = Encoding.Default.GetBytes("Message to Headers Exchange 'format=pdf'");
        await channel.BasicPublishAsync("headers.exchange","",false, properties,messagebuffer);
        Console.WriteLine("Message Sent From :-headers.exchange");
        Console.WriteLine("Routing Key :- Routing key is Not required for headers exchange");
        Console.WriteLine("Message Sent");
    }
    

}
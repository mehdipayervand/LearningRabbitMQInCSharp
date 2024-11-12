using System.Text;
using RabbitMQ.Client;

namespace RequestDirectProducer;

public class DirectMessage
{
    private const string UserName = "guest";
    private const string Password = "guest";
    private const string HostName = "localhost";

    public async Task SendMessage()
    {

        var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
        {
            UserName = UserName,
            Password = Password,
            HostName = HostName
        };

        var connection = await connectionFactory.CreateConnectionAsync();
        IChannel channel = await connection.CreateChannelAsync();
       
        byte[] messageBuffer1 = Encoding.Default.GetBytes("Direct Message 1");
        await channel.BasicPublishAsync("request.exchange","directexchange_key",messageBuffer1);
        Console.WriteLine("Message 1 Sent");
        
        byte[] messageBuffer2 = Encoding.Default.GetBytes("Direct Message 2");
        await channel.BasicPublishAsync("request.exchange","directexchange_key",messageBuffer2);
        Console.WriteLine("Message 2 Sent");
        
    }
}
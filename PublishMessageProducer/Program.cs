using System.Text;
using RabbitMQ.Client;

namespace PublishMessageProducer;

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
        var model = await connection.CreateChannelAsync();

        // await model.ExchangeDeclareAsync("demoExchange",ExchangeType.Direct,true);
        // Console.WriteLine("Creating Exchange");
        //
        // await model.QueueDeclareAsync("demoQueue",true,false,false,null);
        // Console.WriteLine("Creating Queue");
        //
        // await model.QueueBindAsync("demoQueue", "demoExchange","directexchange_key");
        // Console.WriteLine("Creating Binding");

        var message = "Hello world!";
        byte[] messageBuffer = Encoding.Default.GetBytes(message);
        await model.BasicPublishAsync("demoExchange","directexchange_key",messageBuffer);
        Console.WriteLine("Message Sent");
        
        Console.ReadLine();
    }
}
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


//classlarda yazılan RabbitMQ kodları. Console uygulamasında giden verileri ekrana yazdırıyor
var factory = new ConnectionFactory
{
    HostName = "localhost"
};
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("ShoppingList", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message received: {message}");
};

channel.BasicConsume(queue: "ShoppingList", autoAck: true, consumer: consumer);

Console.ReadKey();
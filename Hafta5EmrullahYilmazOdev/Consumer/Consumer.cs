using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Consumer
{
    public class Consumer : BackgroundService
    {
        private readonly ILogger<Consumer> _logger;

        public Consumer(ILogger<Consumer> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.UserName = ConnectionFactory.DefaultUser;
                factory.Password = ConnectionFactory.DefaultPass;
                factory.VirtualHost = ConnectionFactory.DefaultVHost;
                factory.HostName = "localhost";
                factory.Port = AmqpTcpEndpoint.UseDefaultPort;
                

                var connection = factory.CreateConnection();

                var channel = connection.CreateModel();

                channel.QueueDeclare("QueuName", false, false, false);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, args) =>
                {
                    var message = JsonSerializer.Deserialize<Consumer>(Encoding.UTF8.GetString(args.Body.ToArray()));
                    foreach (PropertyInfo p in message.GetType().GetProperties())
                        Console.WriteLine(p.Name + " : " + p.GetValue(message));
                    Console.WriteLine();
                };

                channel.BasicConsume("QqueuName", false, consumer);

            }
        }
    }
}

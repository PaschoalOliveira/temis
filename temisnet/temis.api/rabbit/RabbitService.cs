using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace temis.api.rabbit
{
    public class RabbitService
    {
        public void enviarMensagem(){
            var connectionFactory = new ConnectionFactory()
                        {
                            HostName = "127.0.0.1",
                            Port = 5672,
                            UserName = "guest",
                            Password = "guest",
                        };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var teste = "mensagem1";

                channel.QueueDeclare(
                    queue: "tests",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message =
                    $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - " +
                    $"Message content: {teste}";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                        routingKey: "tests",
                                        basicProperties: null,
                                        body: body);
            }
        }

    public string consumirMensagem(){

        var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "tests",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                var mensagem = "";
                consumer.Received += (sender, eventArgs) =>
                {
                    mensagem = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

                    Console.WriteLine(Environment.NewLine + "[New message received] " + mensagem);
                };

                channel.BasicConsume(queue: "tests",
                     autoAck: true,
                     consumer: consumer);

                //Console.WriteLine("Waiting messages to proccess");
                return mensagem;
            }
    }
    }
}
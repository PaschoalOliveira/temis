using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace temis.api.rabbit
{
    public class RabbitService
    {
        public static void enviarMensagem()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
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

        public static string consumirMensagem()
        {

            /*   var connectionFactory = new ConnectionFactory()
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

                      var consumer = new AsyncEventingBasicConsumer(channel);

                      string mensagem = null;

                      consumer.Received +=  async (sender, eventArgs) => 
                      {
                          mensagem =  await Task.Run(() => Encoding.UTF8.GetString(eventArgs.Body.ToArray()));

                          Console.WriteLine(Environment.NewLine + "[New message received] " + mensagem);
                      };

                      // channel.BasicConsume(queue: "tests",
                      //      autoAck: true,
                      //      consumer: consumer);
                       BasicGetResult result = channel.BasicGet("tests", true);

                      //Console.WriteLine("Waiting messages to proccess");
                      return  mensagem; */

            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare("tests", false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult result = channel.BasicGet("tests", true);
                    if (result == null)
                    {
                        return "merdou";
                    }
                    return Encoding.UTF8.GetString(result.Body.ToArray());
                }
            }
        }
    }
}

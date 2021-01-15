
using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class Connection
{
    public IConnection GetConnection(string hostName, string userName, string password)
    {
        ConnectionFactory connectionFactory = new ConnectionFactory();
        connectionFactory.HostName = hostName;
        connectionFactory.UserName = userName;
        connectionFactory.Password = password;
        return connectionFactory.CreateConnection();
    }

    public static void Send(string queue, string data)
    {
        using (IConnection connection = new ConnectionFactory().CreateConnection())
        {
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null);
                channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
            }
        }
    }

    public  static string Receive(string queue)
    {
        using (IConnection connection = new ConnectionFactory().CreateConnection())
        {
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                BasicGetResult result = channel.BasicGet(queue, true);
                if(result == null)
                {
                    return "merdou";
                }
                return Encoding.UTF8.GetString(result.Body.ToArray());
            }
        }
    }
}
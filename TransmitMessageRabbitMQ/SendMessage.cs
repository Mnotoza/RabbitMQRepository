using System;
using System.Text;
using RabbitMQ.Client;

namespace TransmitMessageRabbitMQ
{
   class SendMessage
   {
      public static void Main(string[] args)
      {
         var factory = new ConnectionFactory() {HostName = "localhost"};
         using (var connection = factory.CreateConnection())
         {
            using (var channel = connection.CreateModel())
            {
               channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false,
                  arguments: null);

               Console.WriteLine("Mfundiso");
               string name = "Mfundiso";
               string message = string.Format("Hello my name is,{0}", name);
               var body = Encoding.UTF8.GetBytes(message);

               channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
               Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
         }
      }
   }
}

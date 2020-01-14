﻿using System;
using System.Text;
using RabbitMQ.Client;
namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasecTest", false, false, false, null);

                string message = "Getting startes win .Net Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "Basic Test",null, body);
                Console.WriteLine("Sent message {0} ...", message);
            }

            Console.WriteLine("Press enter to exit ..");
            Console.ReadLine();
        }
    }
}
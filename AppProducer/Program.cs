using Contracts;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;
using System;

namespace AppProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var bus = InitializeBusControl();
            bus.Start();

            string text = "";
            PublishMessage(text, bus);
            bus.Stop();
        }
        private static IBusControl InitializeBusControl()
        {
            return Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri("rabbitmq://localhost/"), h => { }));
        }
        private static void PublishMessage(string text, IBusControl bus)
        {
            while (text != "quit")
            {
                Console.Write("Enter a message: ");
                text = Console.ReadLine();

                var message = new OperationMessage() {What = text, When = DateTime.Now};
                bus.Publish<Operation>(message);
            }
        }
    }
}

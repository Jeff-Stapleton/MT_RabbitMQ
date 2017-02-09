using MassTransit;
using System;
using MassTransit.Log4NetIntegration.Logging;

namespace AppConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var bus = InitializeBusControl();
            bus.Start();
            Console.ReadKey();
            bus.Stop();
        }
        private static IBusControl InitializeBusControl()
        {
            return Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });

                x.ReceiveEndpoint(host, "BackEndStack_AppConsumer", e => e.Consumer<OperationConsumer>());
            });
        }
    }
}

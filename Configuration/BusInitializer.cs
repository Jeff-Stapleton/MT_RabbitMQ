using MassTransit;
using MassTransit.Log4NetIntegration.Logging;
using System;

namespace Configuration
{
    public class BusInitializer
    {
        public static IBusControl CreateBus(string queueName)
        {
            Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
                x.Host(new Uri("rabbitmq://localhost/"), h => { }));
            bus.Start();

            return bus;
        }
    }
}

using Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace AppConsumer
{
    class OperationConsumer : IConsumer<Operation>
    {
        public Task Consume(ConsumeContext<Operation> message)
        {
            Console.Write("TXT: " + message.Message.What);
            Console.Write("  SENT: " + message.Message.When.ToString());
            Console.Write("  PROCESSED: " + DateTime.Now.ToString());
            Console.WriteLine(" (" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() + ")");
            return Task.FromResult(0);
        }
    }
}

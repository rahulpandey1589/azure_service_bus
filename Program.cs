using azure_messaging_system.Helpers;
using azure_messaging_system.Processor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace azure_messaging_system
{
    class Program
    {
        private static string queueName = "demo-test";
        private static string connectionString = "";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Azure Service Bus Configuraton.");
            Console.WriteLine("-------------------------------------------------------------------");

            Program p = new Program();

            ServiceBusManagementHelper serviceMgmtHelper
                 = new ServiceBusManagementHelper(connectionString);

            if (!await serviceMgmtHelper.DoesQueueExistsAsync(queueName))
            {
                await serviceMgmtHelper.CreateQueue(queueName);
            }

            await p.SendMessageToQueue();

            await p.ReceiveMessageFromQueue();
        }


        private async Task SendMessageToQueue()
        {
            try
            {
                Sender senderObj
                      = new Sender();

              await  senderObj.SendMessageAsync(connectionString, queueName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task ReceiveMessageFromQueue()
        {
            try
            {
                Receiver receiverObj
                     = new Receiver();

              await  receiverObj.ReceiveMessageAsync(connectionString, queueName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

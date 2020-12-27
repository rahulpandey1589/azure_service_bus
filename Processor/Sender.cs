using Azure.Messaging.ServiceBus;
using azure_messaging_system.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace azure_messaging_system.Processor
{
    public class Sender
    {
        public async Task SendMessageAsync(string connectionString,string queueName)
        {
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                ServiceBusSender sender = client.CreateSender(queueName);

                ServiceBusMessage message = new ServiceBusMessage(GetQueueMessage());

                await sender.SendMessageAsync(message);
            }
        }

        private string GetQueueMessage()
        {
            QueueMessageModel model = new QueueMessageModel()
            {
                TransactionId  = Guid.NewGuid().ToString(),
                SenderType = SenderType.Admin
            };

            return JsonConvert.SerializeObject(model);

        }


    }
}

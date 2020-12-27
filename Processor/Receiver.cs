using Azure.Messaging.ServiceBus;
using azure_messaging_system.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace azure_messaging_system.Processor
{
    public class Receiver
    {
        public async Task ReceiveMessageAsync(string connectionString,string queueName)
        {

            try
            {
                await using (ServiceBusClient client = new ServiceBusClient(connectionString))
                {
                    ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions()
                    { 
                        ReceiveMode = ServiceBusReceiveMode.PeekLock
                    });

                    processor.ProcessMessageAsync += ProcessQueueMessageAsync;

                    processor.ProcessErrorAsync += ProcessErrorMessageAsync;

                    await processor.StartProcessingAsync();

                    Console.WriteLine("Wait for a minute and then press any key to end the processing");

                    Console.ReadKey();

                    // stop processing 
                    Console.WriteLine("\nStopping the receiver...");

                    await processor.StopProcessingAsync();

                    Console.WriteLine("Stopped receiving messages");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private Task ProcessErrorMessageAsync(ProcessErrorEventArgs arg)
        {
            System.Console.WriteLine(arg.Exception.Message);
            return Task.CompletedTask;
        }

        private async Task ProcessQueueMessageAsync(ProcessMessageEventArgs arg)
        {
            string body = arg.Message.Body.ToString();

            QueueMessageModel queueMessageModel = JsonConvert.DeserializeObject<QueueMessageModel>(body);

            System.Console.WriteLine($"The queue message body is {queueMessageModel.TransactionId}");

            await arg.CompleteMessageAsync(arg.Message);
        }
    }
}

using Microsoft.Azure.ServiceBus.Management;
using System;
using System.Threading.Tasks;

namespace azure_messaging_system.Helpers
{
    public class ServiceBusManagementHelper
    {
        private readonly ManagementClient managementClient;
        private readonly CreateQueueHelper queueHelper;

        public ServiceBusManagementHelper(string connectionString)
        {
            this.queueHelper = new CreateQueueHelper();
            this.managementClient = new ManagementClient(connectionString);
        }

        public async Task CreateQueue(string queuePath)
        {
            try
            {
                await managementClient.CreateQueueAsync(queueHelper.CreateQueueDescriptionObject(queuePath));
            }
            catch(MessagingEntityAlreadyExistsException entityAlreadyExist)
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DoesQueueExistsAsync(string queuePath)
        {
            return await managementClient.QueueExistsAsync(queuePath);
        }
    }
}

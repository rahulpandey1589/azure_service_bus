using Microsoft.Azure.ServiceBus.Management;

namespace azure_messaging_system.Helpers
{
   public class CreateQueueHelper
    {

        public QueueDescription CreateQueueDescriptionObject(string queueName)
        {

            QueueDescription queueDescription = new QueueDescription(queueName)
            {
                
            };

            return queueDescription;
        }

    }
}

using Microsoft.Azure.ServiceBus.Management;
using System;

namespace azure_messaging_system.Helpers
{
   public class CreateQueueHelper
    {

        public QueueDescription CreateQueueDescriptionObject(string queueName)
        {
            QueueDescription queueDescription = new QueueDescription(queueName)
            {
                MaxSizeInMB = 1024,
                RequiresDuplicateDetection = true,
                DuplicateDetectionHistoryTimeWindow  = TimeSpan.FromMinutes(10),
                RequiresSession = false,
                MaxDeliveryCount = 20,
                DefaultMessageTimeToLive = TimeSpan.FromMinutes(1),
                EnableDeadLetteringOnMessageExpiration = true,
                EnablePartitioning = true
            };

            return queueDescription;
        }
    }
}

using azure_messaging_system.Helpers;
using System;
using System.Threading.Tasks;

namespace azure_messaging_system
{
    class Program
    {
        private static string connectionString = "";
        
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Azure Service Bus Configuraton.");
            Console.WriteLine("-------------------------------------------------------------------");


            ServiceBusManagementHelper serviceMgmtHelper
                 = new ServiceBusManagementHelper(connectionString);



            await serviceMgmtHelper.CreateQueue("demo-test");


        }
    }
}

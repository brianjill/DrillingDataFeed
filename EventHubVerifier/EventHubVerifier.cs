using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;


namespace EventHubVerifier
{
    public class EventHubVerifier
    {
        public static void Main(string[] args)
        {
            Console.Title = "Receiver - witsmldemo";

            string eventHubConnectionString = "Endpoint=sb://witsmldemo-ns.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=aOP/nwCOa5t1+29CaLLjF3uQFTreigoRc23L1WhkQyU=";
            string eventHubName = "witsmldemo";
            string storageAccountName = "witsmldemo";
            string storageAccountKey = "QT72OJiPf1ec9MhXZGH4HNChm7fAocECHR/YtBf9J9vvEKHu70XENG/5DHW6OE9j8UGZykaMcpmdBkLoleklAQ==";
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageAccountName, storageAccountKey);

            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString, storageConnectionString);
            Console.WriteLine("Registering EventProcessor...");
            var options = new EventProcessorOptions();
            options.ExceptionReceived += (sender, e) => { Console.WriteLine(e.Exception); };
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>(options).Wait();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
    }
}

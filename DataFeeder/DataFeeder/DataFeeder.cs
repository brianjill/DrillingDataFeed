using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataParser;
using Microsoft.ServiceBus.Messaging;

namespace DataFeeder
{
    public class DataFeeder
    {
        private static string _connectionString = "Endpoint=sb://witsmldemo-ns.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=B19j5hx3m3+GQSn9QfYes2gfQIXSVxriSAiyp1abTGE=;EntityPath=witsmldemo";
        private static readonly EventHubClient _eventHubClient = EventHubClient.CreateFromConnectionString(_connectionString);
        public static void Main(string[] args)
        {
            for (;;) {
                var csvDynamic = new DataParser<CsvDynamicData>(new CsvDynamicData());
                csvDynamic.Parse();
                var toWrite = csvDynamic.TransformToJson();
                Console.Write(toWrite);
                _eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(toWrite)));
            }

        }
    }
}

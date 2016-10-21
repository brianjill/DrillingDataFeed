using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            var csvDynamic = new DataParser<CsvDynamicData>(new CsvDynamicData());
            csvDynamic.Parse();

            var list = csvDynamic.GetItems();

            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    var elapsedSpan = new TimeSpan(list[i].Ticks - list[i - 1].Ticks);

                    var miliseconds = Convert.ToInt32(elapsedSpan.TotalMilliseconds);
                    Thread.Sleep(miliseconds);
                }


                var toWrite = csvDynamic.TranformToJson(i);
                Console.Write(toWrite);
                _eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(toWrite)));

            }
            
        }
    }
}

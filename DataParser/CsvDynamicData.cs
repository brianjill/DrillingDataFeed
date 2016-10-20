using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class CsvDynamicData : AbstractData
    {
        private List<string> _labels;
        public CsvDynamicData()
        {
            FilePath = File.Exists(BasePath + @"\data\DynamicData.csv") ? BasePath + @"\data\DynamicData.csv" : string.Empty;
            _labels = new List<string>();
        }
        public override void Parse()
        {
            if (string.IsNullOrEmpty(FilePath)) return;

            var reader = new StreamReader(File.OpenRead(FilePath));

            List<CsvDynamicItem> listData = new List<CsvDynamicItem>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                DateTime tempDate;
                if (!DateTime.TryParse(values[0], out tempDate))
                {
                    _labels = values.ToList();
                    continue;
                }
                    
                CsvDynamicItem item = new CsvDynamicItem();
                item.Time = tempDate.ToShortTimeString();
                item.Ticks = tempDate.Ticks;

                item.Properties = new Dictionary<string, string>();

                for (var i=0;i<values.Length;i++)
                {
                    item.Properties.Add(_labels[i],values[i]);
                }
                
                listData.Add(item);
            }

            Items = new List<Item>(listData);
        }
    }
}

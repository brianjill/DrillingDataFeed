using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataParser
{
    public class CsvData : AbstractData
    {
        private TimeSpan _elapsedSpan;
        private string _lastFullActivityCode = "";
        private double _fullActivityCodeDuration = 0;

        public override void Parse()
        {
            if (string.IsNullOrEmpty(FilePath)) return;

            var reader = new StreamReader(File.OpenRead(FilePath));

            List<CsvItem> listData = new List<CsvItem>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                DateTime tempDate;
                if (!DateTime.TryParse(values[0], out tempDate))
                    continue;

                Random rnd = new Random();

                CsvItem item = new CsvItem();
                item.ActivityTime = values[0];
                item.Ticks = tempDate.Ticks;
                item.FullActivityCode = GetDataAsString(values[1]);
                item.BitDepth = GetDataAsFloat(values[2]);
                item.ModelBitDepth = item.BitDepth - rnd.Next(0, 5);
                item.BlockPos = GetDataAsFloat(values[3]);
                item.ModelBlockPos = item.BlockPos - rnd.Next(0, 2);
                item.TotalDepth = GetDataAsFloat(values[4]);
                item.HookLoad = GetDataAsFloat(values[5]);
                item.TDTorque = GetDataAsFloat(values[6]);
                item.ModelTDTorque = item.TDTorque - GetRandomDouble(0, 0.1);
                item.TDSpeed = GetDataAsFloat(values[7]);
                item.STPPressure = GetDataAsFloat(values[8]);
                item.WeightOnBit = GetDataAsFloat(values[9]);
                item.BoB = GetDataAsFloat(values[10]);
                item.BitSize = GetDataAsFloat(values[11]);
                item.AccumTripIn = GetDataAsFloat(values[12]);
                item.AccumTripOut = GetDataAsFloat(values[13]);
                item.DiffPress = GetDataAsFloat(values[14]);
                item.TripTankGL = GetDataAsFloat(values[15]);
                item.ROPAvg = GetDataAsFloat(values[16]);
                item.ROPCutUnit = GetDataAsFloat(values[17]);
                item.SvyInclination = GetDataAsFloat(values[18]);
                item.BitTVD = GetDataAsFloat(values[19]);
                item.Total_Vol = GetDataAsFloat(values[20]);
                item.RotaryTorque = GetDataAsFloat(values[21]);
                item.RotarySpeed = GetDataAsFloat(values[22]);
                item.TT_Vol = GetDataAsFloat(values[23]);

                listData.Add(item);
            }

            var list = listData.OrderBy(x => x.Ticks).ToList();

            //add the duration value between FullActivityCodes
            for (int i = 0; i < list.Count - 1; i++)
            {
                _elapsedSpan = new TimeSpan(list[i + 1].Ticks - list[i].Ticks);

                if (_lastFullActivityCode != list[i].FullActivityCode)
                {
                    _fullActivityCodeDuration = 0;
                    _lastFullActivityCode = list[i].FullActivityCode;
                }
                else
                {
                    _fullActivityCodeDuration += _elapsedSpan.TotalSeconds;
                }

                list[i].FullActivityCodeDuration = _fullActivityCodeDuration;
            }

            Items = new List<Item>(list.FindAll(e => e.Ticks >= DateTime.Now.Ticks).ToList());
            
        }

        public CsvData()
        {
            FilePath = File.Exists(BasePath + @"\data\CementData.csv") ? BasePath + @"\data\CementData.csv" : string.Empty;
        }
    }
}

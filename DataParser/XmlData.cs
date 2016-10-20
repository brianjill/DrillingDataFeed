using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataParser.Interface;

namespace DataParser
{
    public class XmlData : AbstractData
    {
        
        public override void Parse()
        {
            if(string.IsNullOrEmpty(FilePath)) return;

            XmlTextReader reader = new XmlTextReader(FilePath);
            char[] delimiterChars = { ',' };
            List<XmlItem> listData = new List<XmlItem>();

            while (reader.Read())
            {
                if (reader.Value.Split(delimiterChars).Length == 25)
                {
                    string[] readerData = reader.Value.Split(delimiterChars);

                    XmlItem item = new XmlItem();
                    item.Time = readerData[0];
                    item.Ticks = Convert.ToDateTime(readerData[0]).Ticks;
                    item.STRATE1 = GetDataAsFloat(readerData[1]);
                    item.BLOCKCOMP = GetDataAsFloat(readerData[2]);
                    item.CEMTEMPOUT = GetDataAsFloat(readerData[3]);
                    item.ECDCS = GetDataAsFloat(readerData[4]);
                    item.CEMSTAGE = GetDataAsFloat(readerData[5]);
                    item.FLOWOUTPC = GetDataAsFloat(readerData[6]);
                    item.CEMIVOLPUMP = GetDataAsFloat(readerData[7]);
                    item.STROKESUM = GetDataAsFloat(readerData[8]);
                    item.CEMFLOWINC = GetDataAsFloat(readerData[9]);
                    item.PUMP = GetDataAsFloat(readerData[10]);
                    item.CEMPUMPPR = GetDataAsFloat(readerData[11]);
                    item.CEMFLOWIN = GetDataAsFloat(readerData[12]);
                    item.CEMWTIN = GetDataAsFloat(readerData[13]);
                    item.HKLD = GetDataAsFloat(readerData[14]);
                    item.CEMFLOWOUT = GetDataAsFloat(readerData[15]);
                    item.CEMTVOLPUMP = GetDataAsFloat(readerData[16]);
                    item.CEMCVOLPUMP = GetDataAsFloat(readerData[17]);
                    item.CEMCUMRETURNS = GetDataAsFloat(readerData[18]);
                    item.CEMWTOUT = GetDataAsFloat(readerData[19]);
                    item.CEMTEMPIN = GetDataAsFloat(readerData[20]);
                    item.ANNVEL_MMAX = GetDataAsFloat(readerData[21]);
                    item.FLOWIN = GetDataAsFloat(readerData[22]);
                    item.STRATE3 = GetDataAsFloat(readerData[23]);
                    item.STRATE2 = GetDataAsFloat(readerData[24]);

                    listData.Add(item);

                }
            }

            Items = new List<Item>(listData.FindAll(e => e.Ticks >= DateTime.Now.Ticks));
        }

        public XmlData()
        {
            FilePath = File.Exists(BasePath + @"\data\CementData.xml") ? BasePath + @"\data\CementData.xml" : string.Empty;
        }
    }
}

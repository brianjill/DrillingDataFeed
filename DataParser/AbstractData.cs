using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataParser.Interface;

namespace DataParser
{
    public abstract class AbstractData: IParse
    {
        //xml, csv etc
        public string ItemType { get; set; }
        public string FilePath { get; set; }
        public string BasePath { get; set; }
        
        public abstract void Parse();

        public List<Item> Items { get; set; }

        public float GetDataAsFloat(string text)
        {
            return !string.IsNullOrEmpty(text) && text != "NULL" ? float.Parse(text, System.Globalization.CultureInfo.InvariantCulture) : 0;
        }

        public string GetDataAsString(string text)
        {
            return !string.IsNullOrEmpty(text) ? text : "";
        }

        public double GetRandomDouble(int minValue, double maxValue)
        {
            Random random = new Random();
            double number = random.NextDouble() * (maxValue - minValue) + minValue;
            if (number < 0)
                number *= -1;

            return Math.Round(number, 2); ;
        }
        protected AbstractData()
        {
            BasePath = ConfigurationManager.AppSettings["XmlDataFilePath"];
        }
    }

    
}

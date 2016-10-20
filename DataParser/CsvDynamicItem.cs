using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class CsvDynamicItem : Item
    {
        public string Time { get; set; }
        public Dictionary<string,string> Properties { get; set; }
    }
}

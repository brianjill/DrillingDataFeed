using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class XmlItem : Item
    {
        public string Time { get; set; }
        
        public float TimeStamp { get; set; }
        public float STRATE1 { get; set; }
        public float BLOCKCOMP { get; set; }
        public float CEMTEMPOUT { get; set; }
        public float ECDCS { get; set; }
        public float CEMSTAGE { get; set; }
        public float FLOWOUTPC { get; set; }
        public float CEMIVOLPUMP { get; set; }
        public float STROKESUM { get; set; }
        public float CEMFLOWINC { get; set; }
        public float PUMP { get; set; }
        public float CEMPUMPPR { get; set; }
        public float CEMFLOWIN { get; set; }
        public float CEMWTIN { get; set; }
        public float HKLD { get; set; }
        public float CEMFLOWOUT { get; set; }
        public float CEMTVOLPUMP { get; set; }
        public float CEMCVOLPUMP { get; set; }
        public float CEMCUMRETURNS { get; set; }
        public float CEMWTOUT { get; set; }
        public float CEMTEMPIN { get; set; }
        public float ANNVEL_MMAX { get; set; }
        public float FLOWIN { get; set; }
        public float STRATE3 { get; set; }
        public float STRATE2 { get; set; }

        public XmlItem()
        {
            
        }
    }
}

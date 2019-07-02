using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace HoneywellAmericanMeterBadges
{
    public class Check4Duplicates
    {
        public Check4Duplicates() { }

        public bool DuplicatesYN { get; set; }
        public string OrderNumber { get; set; }
        public string CustNumber { get; set; }
        public string Beginning { get; set; }
        public string Ending { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Year { get; set; }
    }


}

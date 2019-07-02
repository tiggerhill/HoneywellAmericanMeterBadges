using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneywellAmericanMeterBadges.SerialsManufacturing
{
    public class SerialsManufacturing
    {
        public SerialsManufacturing() { }

        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string BadgeNumber { get; set; }
        public string RequirementCode { get; set; }
        public string Year { get; set; }
        public char IncludeYear { get; set; }
        public string Prefix { get; set; }
        public char IncludePrefix { get; set; }
        public Int32 BeginningSerial { get; set; }
        public Int32 EndingSerial { get; set; }
        public Int32 Count { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}

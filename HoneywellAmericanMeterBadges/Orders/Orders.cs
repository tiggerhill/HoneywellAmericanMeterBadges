using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneywellAmericanMeterBadges.Orders
{
    public class Order
    {
        public Order() { }

        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderNotes { get; set; }

        public string MfgFinishedBadge { get; set; }
        public string MfgRequirementCode { get; set; }
        public string MfgYear { get; set; }
        public string MfgYearInclude { get; set; }
        public string MfgPrefix { get; set; }
        public string MfgPrefixInclude { get; set; }
        public Int32 MfgBeginningSerial { get; set; }
        public Int32 MfgEndingSerial { get; set; }
        public Int32 MfgQuantity { get; set; }
        public string MfgStatus { get; set; }
        public string MfgNotes { get; set; }
        

        public string CustFinishedBadge { get; set; }
        public string CustPrefix { get; set; }
        public string CustPrefixInclude { get; set; }
        public string CustSuffix { get; set; }
        public string CustSuffixInclude { get; set; }
        public Int32 CustBeginningSerial { get; set; }
        public Int32 CustEndingSerial { get; set; }
        public Int32 CustQuantity { get; set; }
        public string CustStatus { get; set; }
        public string CustNotes { get; set; }
        
    }
}

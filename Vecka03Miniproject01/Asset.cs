using System;
using System.Collections.Generic;
using System.Text;

namespace Vecka03Miniproject01
{
    public class Asset
    {
        public int ExpirationPeriod { get; set; }
        public string HardwareType { get; set; }
        public string ModelName { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string OfficeLocation { get; set; }

        public string Currency { get; set; }


    }
}

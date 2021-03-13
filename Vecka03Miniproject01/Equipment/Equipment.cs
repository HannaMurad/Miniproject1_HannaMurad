using System;
using System.Collections.Generic;
using System.Linq;


namespace Vecka03Miniproject01
{
    public abstract class Equipment
    {
        public string ModelName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }

        //------------------- Constructor Chain ---------------------
        public Equipment() : this(string.Empty, DateTime.Now, 0M)
        {

        }
        public Equipment(string modelName, DateTime purchaseDate, decimal purchasePrice)
        {
            ModelName = modelName;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
        }
        public abstract string GetEquipmentType();
        
    }
}

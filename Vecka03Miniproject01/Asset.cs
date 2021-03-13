using System;
using System.Collections.Generic;
using System.Text;
using Vecka03MiniprojectCurrencyExchange01;

namespace Vecka03Miniproject01
{
    
    public class Asset
    {
        //------------- Equipment Related Properties and Fields -------------------
        public Equipment EquipmentInfo { get; set; }

        private AssetStatus status;
        public AssetStatus Status { 
            get 
            {
                if (DateTime.Compare(EquipmentInfo.PurchaseDate.AddMonths(33), DateTime.Now) >= 0)
                    status = AssetStatus.AlmostDepricated;
                else if (DateTime.Compare(EquipmentInfo.PurchaseDate.AddMonths(30), DateTime.Now) >= 0)
                    status = AssetStatus.SoonDepricated;
                else status = AssetStatus.New;

                return status;
            } 
            private set { }
        }
        //------------- Office Related Properties and Fields-----------------------
        public Office OfficeInfo { get; set; }

        private decimal localPrice;
        public decimal LocalPrice { 
            get 
            {
                localPrice = CurrencyConverter.GetExchangeRate("usd", OfficeInfo.Currency, EquipmentInfo.PurchasePrice);
                return localPrice;
            } 
            private set { } 
        }

        //----------- Constructor Chain------------------
        public Asset() : this(new Equipment(), new Office())
        {

        }
        public Asset(Equipment equipmentInfo, Office officeInfo)
        {
            EquipmentInfo = equipmentInfo;
            OfficeInfo = officeInfo;
        }

    }
    [Flags]
    public enum AssetStatus { New = 0b_0000_0001, SoonDepricated = 0b_000_0010, AlmostDepricated = 0b_000_0100 }
}

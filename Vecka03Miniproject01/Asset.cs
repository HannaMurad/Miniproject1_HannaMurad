using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
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
                if (DateTime.Compare(EquipmentInfo.PurchaseDate.AddMonths(33), DateTime.Now) <= 0)
                    status = AssetStatus.AlmostDepricated;
                else if (DateTime.Compare(EquipmentInfo.PurchaseDate.AddMonths(30), DateTime.Now) <= 0)
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
        public Asset(string modelName, DateTime purchaseDate, decimal purchasePrice, Location officeLocation): this()
        {
            EquipmentInfo.ModelName = modelName;
            EquipmentInfo.PurchaseDate = purchaseDate;
            EquipmentInfo.PurchasePrice = purchasePrice;
            OfficeInfo.OfficeLocation = officeLocation;
        }
        public void ReadAsset()
        {
            InputAndValidation.ReadAndValidate(out string modelName, "Enter Model Name");
            EquipmentInfo.ModelName = modelName;

            InputAndValidation.ReadAndValidate(out DateTime purchaseDate, "Enter Purchase Date");
            EquipmentInfo.PurchaseDate = purchaseDate;

            InputAndValidation.ReadAndValidate(out decimal purchasePrice, "Enter Purchase Price");
            EquipmentInfo.PurchasePrice = purchasePrice;

            Location allLocations = Location.GreatBritain | Location.Sweden | Location.UnitedStates;
            InputAndValidation.ReadAndValidate(out Location officeLocation, "Enter Office Location " + allLocations);
            OfficeInfo.OfficeLocation = officeLocation;
        }
            public void WriteAsset()
        {
            if (Status == AssetStatus.AlmostDepricated) Console.ForegroundColor = ConsoleColor.Red;
            else if (Status == AssetStatus.SoonDepricated) Console.ForegroundColor = ConsoleColor.Yellow;

            CultureInfo.CurrentCulture = new CultureInfo(OfficeInfo.CultureName);

            Console.WriteLine(
                EquipmentInfo.ModelName.PadRight(15) +
                EquipmentInfo.PurchaseDate.ToString("d").PadRight(15) +
                LocalPrice.ToString("c").PadRight(15) +
                OfficeInfo.OfficeLocation.ToString().PadRight(15)
                );

            Console.ResetColor();
        }

    }
    [Flags]
    public enum AssetStatus { New = 0b_0000_0001, SoonDepricated = 0b_000_0010, AlmostDepricated = 0b_000_0100 }
}

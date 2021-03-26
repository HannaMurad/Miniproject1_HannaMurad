using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Vecka03MiniprojectCurrencyExchange01;

namespace Domain
{
    
    public class Asset
    {
        public int Id { get; set; }
        //------------- Equipment Related Properties and Fields -------------------
        public Equipment Equipment { get; set; }

        private AssetStatus status;
        public AssetStatus Status { 
            get 
            {
                if (DateTime.Compare(Equipment.PurchaseDate.AddMonths(33), DateTime.Now) <= 0)
                    status = AssetStatus.AlmostDepricated;
                else if (DateTime.Compare(Equipment.PurchaseDate.AddMonths(30), DateTime.Now) <= 0)
                    status = AssetStatus.SoonDepricated;
                else status = AssetStatus.New;

                return status;
            } 
             set { }
        }
        /*private EquipmentType type;
        public EquipmentType Type
        {
            get
            {
                if (Equipment is Desktop)
                    type = EquipmentType.Desktop;
                else if (Equipment is Laptop)
                    type = EquipmentType.Laptop;
                else type = EquipmentType.Mobile;

                return type;
            }
            set { }
        }*/
        //------------- Office Related Properties and Fields-----------------------
        public Office Office { get; set; }

        private decimal localPrice;
        public decimal LocalPrice { 
            get 
            {
                localPrice = CurrencyConverter.GetExchangeRate("usd", Office.Currency, Equipment.PurchasePrice);
                return localPrice;
            } 
            set
            {
                localPrice = CurrencyConverter.GetExchangeRate("usd", Office.Currency, value); 
            } 
        }

        //-------------------------------- Constructors -----------------------------------
        public Asset() : this(new Desktop(), new Office())
        {

        }
        public Asset(Equipment equipmentInfo, Office officeInfo)
        {
            Equipment = equipmentInfo;
            Office = officeInfo;

            //LocalPrice = Equipment.PurchasePrice;
        }
        public Asset(EquipmentType equipmentType, string modelName, DateTime purchaseDate, decimal purchasePrice, Location officeLocation)
        {
            Equipment = CreateEquipment(equipmentType);
            Office = new Office();

            Equipment.ModelName = modelName;
            Equipment.PurchaseDate = purchaseDate;
            Equipment.PurchasePrice = purchasePrice;
            Office.OfficeLocation = officeLocation;

            LocalPrice = purchasePrice;
        }
        //----------------------------------------------------------------------------------------
        private Equipment CreateEquipment(EquipmentType equipmentType)
        {
            switch (equipmentType)
            {
                case EquipmentType.Desktop:
                    return new Desktop();
                    
                case EquipmentType.Laptop:
                    return new Laptop();

                case EquipmentType.Mobile:
                    return new Mobile();
                default: return new Desktop();
            }
        }
        //------------------------ read and write asset to console ------------------------------
        public void ReadAsset()
        {
            EquipmentType allEquipment = EquipmentType.Desktop | EquipmentType.Laptop | EquipmentType.Mobile;
            InputAndValidation.ReadAndValidate(out EquipmentType equipmentType, "Enter Equipment type " + allEquipment);
            Equipment = CreateEquipment(equipmentType);

            InputAndValidation.ReadAndValidate(out string modelName, "Enter Model Name");
            Equipment.ModelName = modelName;

            InputAndValidation.ReadAndValidate(out DateTime purchaseDate, "Enter Purchase Date");
            Equipment.PurchaseDate = purchaseDate;

            InputAndValidation.ReadAndValidate(out decimal purchasePrice, "Enter Purchase Price");
            Equipment.PurchasePrice = purchasePrice;

            Location allLocations = Location.GreatBritain | Location.Sweden | Location.UnitedStates;
            InputAndValidation.ReadAndValidate(out Location officeLocation, "Enter Office Location " + allLocations);
            Office.OfficeLocation = officeLocation;
        }
            public void WriteAsset()
        {
            if (Status == AssetStatus.AlmostDepricated) Console.ForegroundColor = ConsoleColor.Red;
            else if (Status == AssetStatus.SoonDepricated) Console.ForegroundColor = ConsoleColor.Yellow;

            CultureInfo.CurrentCulture = new CultureInfo(Office.CultureName);

            Console.WriteLine(
                Equipment.GetType().ToString().PadRight(18) +
                Equipment.ModelName.PadRight(15) +
                Equipment.PurchaseDate.ToString("d").PadRight(15) +
                LocalPrice.ToString("c").PadRight(15) +
                Office.OfficeLocation.ToString().PadRight(15)
                );

            Console.ResetColor();
        }
    }
    [Flags]
    public enum AssetStatus { New = 0b_0000_0001, SoonDepricated = 0b_000_0010, AlmostDepricated = 0b_000_0100 }
    [Flags]
    public enum EquipmentType { Desktop = 0b_0000_0001, Laptop = 0b_000_0010, Mobile = 0b_000_0100 }
}

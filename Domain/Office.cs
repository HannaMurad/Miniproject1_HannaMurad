using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Domain
{
    public class Office
    {
        public Location OfficeLocation { get; set;}
        private string currency;
        public string Currency {
            get 
            {
                currency = OfficeLocation switch
                {
                    Location.GreatBritain => "gbp",
                    Location.Sweden => "sek",
                    Location.UnitedStates => "usd",
                    _ => "usd",
                };
                return currency;
            }
            private set { }     
        }
        private string cultureName;
        public string CultureName { 
            get
            {
                cultureName = OfficeLocation switch
                {
                    Location.GreatBritain => "en-GB",
                    Location.Sweden => "sv-SE",
                    Location.UnitedStates => "en-US",
                    _ => "en-US",
                };
                return cultureName;
            } 
            set { } }
        //--------------------- Constructor Chain --------------------------
        public Office() : this(Location.UnitedStates)
        {

        }
        public Office(Location officeLocation)
        {
            OfficeLocation = officeLocation;
        }

    }

    [Flags]
    public enum Location { GreatBritain = 0b_0000_0001, Sweden = 0b_0000_0010, UnitedStates = 0b_0000_0100 };
}

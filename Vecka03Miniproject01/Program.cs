using System;
using System.Collections.Generic;
using static System.Console;
using System.Globalization;
using System.Xml;
using System.Linq;
using Vecka03MiniprojectCurrencyExchange01;

namespace Vecka03Miniproject01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Location allLocations = Location.GreatBritain | Location.Sweden | Location.UnitedStates;
            InputAndValidation.ReadAndValidate(out Location output, "Please write your location: " + allLocations);
            Console.WriteLine(output);*/

            


            /*
            var assets = new List<Asset>();
            //GetInput(assets);

            var asset1 = new Asset
            {
                HardwareType = "mobile",
                ModelName = "iphone",
                PurchasePrice = 1200,
                PurchaseDate = new DateTime(2020, 12, 05),
                OfficeLocation = "United States"
            };
            assets.Add(asset1);
            var asset2 = new Asset
            {
                HardwareType = "laptop",
                ModelName = "asus",
                PurchasePrice = 1500,
                PurchaseDate = new DateTime(2018, 05, 05),
                OfficeLocation = "Sweden"
            };
            assets.Add(asset2);
            var asset3 = new Asset
            {
                HardwareType = "laptop",
                ModelName = "hp",
                PurchasePrice = 1600,
                PurchaseDate = new DateTime(2021, 12, 05),
                OfficeLocation = "Great Britain"
            };
            assets.Add(asset3);
            var asset4 = new Asset
            {
                HardwareType = "mobile",
                ModelName = "samsung",
                PurchasePrice = 1000,
                PurchaseDate = new DateTime(2019, 12, 05),
                OfficeLocation = "Sweden"
            };
            assets.Add(asset4);
            var asset5 = new Asset
            {
                HardwareType = "desktop",
                ModelName = "lenovo",
                PurchasePrice = 1300,
                PurchaseDate = new DateTime(2018, 07, 05),
                OfficeLocation = "Sweden"
            };
            assets.Add(asset5);


            var sortedAssets = assets.OrderBy(a => a.OfficeLocation).ThenBy(a => a.PurchaseDate).ToList();
            ShowAssets(sortedAssets);
            */
            
            ///////////////////////////////////////////////////////////////////////////////////
            //WriteLine(CultureInfo.CurrentCulture.Name);

            //CultureInfo[] cltrInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);
            //foreach (var culture in cltrInfos)
            //{
            //    WriteLine(culture.Name);
            //}
            
            //XmlDocument doc = new XmlDocument();
            
            //CultureInfo.CurrentCulture = new CultureInfo("en-US");
            //decimal price = 500;
            //CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            //WriteLine(price.ToString("c"));

        }
        private static void GetInput(List<Asset> assets)
        {
            while(true)
            {
                
                WriteLine("Enter to input asset data, q or quit to exit");
                string input = ReadLine().Trim().ToLower();
                if(!string.IsNullOrWhiteSpace(input))
                    if (input[0] == 'q') break;

                var newAsset = new Asset();

                string data;
                WriteLine("Enter Hardware Type");
                data = ReadLine();
                newAsset.HardwareType = data;

                WriteLine("Enter Model Name");
                data = ReadLine();
                newAsset.ModelName = data;

                WriteLine("Enter Purchase Price");
                data = ReadLine();
                if (decimal.TryParse(data, out decimal result))
                {
                    newAsset.PurchasePrice = result;
                }
                else
                {
                    WriteLine("not the write format");
                }

                WriteLine("Enter Purchase Date");
                data = ReadLine();
                if (DateTime.TryParse(data, out DateTime date))
                {
                    newAsset.PurchaseDate = date;
                }
                else
                {
                    WriteLine("not the write format");
                }

                WriteLine("Enter Office Location");
                data = ReadLine();
                newAsset.OfficeLocation = data;

                assets.Add(newAsset);
            }

        }
        private static void ShowAssets(List<Asset> assets)
        {
            foreach (var item in assets)
            {
                TimeSpan expirySpan = DateTime.Now - item.PurchaseDate;
                if (expirySpan.Days >= 1008) Console.ForegroundColor = ConsoleColor.Red;
                else if (expirySpan.Days >= 935) Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ResetColor();

                string toCurrency;
                decimal toPrice = item.PurchasePrice; 
                switch (item.OfficeLocation)
                {
                    case "Great Britain":
                        toCurrency = "gbp";
                        toPrice = Convert.ToDecimal(CurrencyConverter.GetExchangeRate("usd", toCurrency, (float)toPrice));
                        CultureInfo.CurrentCulture = new CultureInfo("en-GB");
                        break;
                    case "Sweden":
                        toCurrency = "sek";
                        toPrice = Convert.ToDecimal(CurrencyConverter.GetExchangeRate("usd", toCurrency, (float)toPrice));
                        CultureInfo.CurrentCulture = new CultureInfo("sv-SE");
                        break;
                    case "United States":
                        CultureInfo.CurrentCulture = new CultureInfo("en-US");
                        break;
                }
                

                WriteLine(
                      item.HardwareType.PadRight(10)
                    + item.ModelName.PadRight(10)
                    + item.PurchaseDate.ToString("d").PadRight(15)
                    + item.OfficeLocation.PadRight(15)
                    + toPrice.ToString("c")
                    ); 
            }
        }

        
    }
}

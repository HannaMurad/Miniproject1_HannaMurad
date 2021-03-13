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
            var assets = new Assets();
            assets.ReadAssetsFromConsole();
            assets.WriteAssetsToConsole();


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
            
            
        }   
    }
}

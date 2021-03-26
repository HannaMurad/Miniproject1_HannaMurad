using System;
using System.Collections.Generic;
using static System.Console;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using System.Text;
using Domain;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var assets = new Assets();
            assets.ReadAssetsFromConsole();
            assets.AllAssets = assets.AllAssets.OrderBy(a => a.OfficeInfo.OfficeLocation).ThenBy(a => a.EquipmentInfo.PurchaseDate).ToList();
            assets.WriteAssetsToConsole();
        }   
    }
}

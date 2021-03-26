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
using Data;

namespace Interface
{
    class Program
    {
        private static Context _context;
        static void Main(string[] args)
        {
            //var assets = File.ReadAllLines("InitialData.csv").Select(ParseFromCsv);
            

            //var assets = new Assets();
            //assets.ReadAssetsFromConsole();
            //assets.AllAssets = assets.AllAssets.OrderBy(a => a.Office.OfficeLocation).ThenBy(a => a.Equipment.PurchaseDate).ToList();
            //assets.WriteAssetsToConsole();

        } 
        public static Asset ParseFromCsv(string Line)
        {
            var columns = Line.Split(',');
            return new Asset();
            //return new Asset
            //{
            //    Type = (EquipmentType)Enum.Parse(EquipmentType, columns[0]),
            //    Equipment = new 
            //}
        }
    }
}

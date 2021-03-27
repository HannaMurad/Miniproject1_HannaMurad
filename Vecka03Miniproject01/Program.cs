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
using Microsoft.EntityFrameworkCore;

namespace Interface
{
    class Program
    {
        private static Context _context = new Context();
        static void Main(string[] args)
        {

            // ---------------- seed database from csv file --------------------
            //var assets = File.ReadAllLines(@"..\..\..\InitialData.csv").Select(ParseFromCsv);
            //_context.Assets.AddRange(assets);
            //_context.SaveChanges();


            // CRUD Read
            //var assets = _context.Assets.Include(a => a.Equipment).Include(a => a.Office).ToList();
            //var assetManager = new Assets();
            //assetManager.AllAssets = assets;
            //assetManager.WriteAssetsToConsole();


            // CRUD Create
            var newAsset = new Asset();
            newAsset.ReadAsset();
            _context.Assets.Add(newAsset);
            _context.SaveChanges();





            //var assets = new Assets();
            //assets.ReadAssetsFromConsole();
            //assets.AllAssets = assets.AllAssets.OrderBy(a => a.Office.OfficeLocation).ThenBy(a => a.Equipment.PurchaseDate).ToList();
            //assets.WriteAssetsToConsole();

        }
        public static Asset ParseFromCsv(string Line)
        {
            var columns = Line.Split(',');

            return new Asset
            {
                Equipment = CreateEquipmentfromCsv(columns[0], columns[1], columns[2], columns[3]),
                Office = new Office((Location)Enum.Parse(typeof(Location), columns[4])),
                LocalPrice = decimal.Parse(columns[3]),
                Status = AssetStatus.New
            };
        }
        public static Equipment CreateEquipmentfromCsv(string type, string modelName, string purchaseDate, string purchasePrise)
        {
            DateTime pd = DateTime.Parse(purchaseDate);
            decimal pp = decimal.Parse(purchasePrise);

            switch (type)
            {
                case "Desktop":
                    return new Desktop(modelName, pd, pp);
                case "Laptop":
                    return new Laptop(modelName, pd, pp);
                case "Mobile":
                    return new Mobile(modelName, pd, pp);
                default:
                    return new Desktop(modelName, pd, pp);
            }

        }
    }
}

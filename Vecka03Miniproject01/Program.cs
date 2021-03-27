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
            // Seed from csv
            //Seed();

            while (true)
            {
                Console.WriteLine("1. Read \n\r2. Add \n\r3. Delete \n\r4. Update\n\r5. Quit");
                InputAndValidation.ReadAndValidate(out int option, "write the option relevant number");
                
                switch (option)
                {
                    case 1:
                        Read();
                        break;
                    case 2:
                        Create();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    default:
                        return;
                }
            }

            // Miniproject 1
            //var assets = new Assets();
            //assets.ReadAssetsFromConsole();
            //assets.AllAssets = assets.AllAssets.OrderBy(a => a.Office.OfficeLocation).ThenBy(a => a.Equipment.PurchaseDate).ToList();
            //assets.WriteAssetsToConsole();
        }
        public static void Seed()
        {
            var assets = File.ReadAllLines(@"..\..\..\InitialData.csv").Select(ParseFromCsv);
            _context.Assets.AddRange(assets);
            _context.SaveChanges();
        }
        public static void Read()
        {
            var assets = _context.Assets.Include(a => a.Equipment).Include(a => a.Office).ToList();
            var assetManager = new Assets();
            assetManager.AllAssets = assets;
            assetManager.WriteAssetsToConsole();
        }
        public static void Create()
        {
            var newAsset = new Asset();
            newAsset.ReadAsset();
            _context.Assets.Add(newAsset);
            _context.SaveChanges();
            Console.WriteLine("asset has been added");
        }
        public static void Delete()
        {
            var ids = _context.Assets.Select(a => a.Id).ToList();
            foreach (var id in ids) Console.Write(id.ToString().PadRight(4));

            bool loop = true;
            while (loop)
            {
                InputAndValidation.ReadAndValidate(out int selectedID, "\n\rEnter Asset ID you want to delete");

                foreach (var id in ids)
                {
                    if (id == selectedID)
                    {
                        var oldAsset = _context.Assets.SingleOrDefault(a => a.Id == selectedID);
                        
                        _context.Assets.Remove(oldAsset);
                        _context.SaveChanges();
                        loop = false;
                    }
                }
                if (loop == true) Console.WriteLine("please write one of the listed IDs");

            }
            Console.WriteLine("asset has been deleted");
        }
        public static void Update()
        {
            var ids = _context.Assets.Select(a => a.Id).ToList();
            foreach (var id in ids) Console.Write(id.ToString().PadRight(4));

            bool loop = true;
            while (loop)
            {
                InputAndValidation.ReadAndValidate(out int selectedID, "\n\rEnter Asset ID you want to update");

                foreach (var id in ids)
                {
                    if (id == selectedID)
                    {
                        var asset = _context.Assets.Where(a => a.Id == selectedID).Include(a => a.Equipment).Include(a => a.Office).SingleOrDefault();
                        InputAndValidation.ReadAndValidate(out string newModel, "enter new model");
                        asset.Equipment.ModelName = newModel;
                        _context.SaveChanges();
                        loop = false;
                    }
                }
                if (loop == true) Console.WriteLine("please write one of the listed IDs");

            }
            Console.WriteLine("asset has been updated");
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

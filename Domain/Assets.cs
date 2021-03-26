using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    
    public class Assets
    {
        public List<Asset> AllAssets { get; set; }

        public Assets()
        {
            AllAssets = new List<Asset>();
        }
        public Assets(List<Asset> assets)
        {
            AllAssets = assets;
        }

        public void ReadAssetsFromConsole()
        {
            while(true)
            {
                Console.WriteLine("Enter Assets Info, Enter to continue q to Quit");
                string input = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(input)) if (input[0] == 'q') break;

                var asset = new Asset();
                asset.ReadAsset();
                AllAssets.Add(asset);
            }    
        }
        public void WriteAssetsToConsole()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(
                "Asset Type".PadRight(18) +
                "Model Name".PadRight(15) +
                "Purchase Date".PadRight(15) +
                "Local Price".PadRight(15) +
                "Office Location".ToString().PadRight(15)
                );
            Console.ResetColor();
            foreach (var asset in AllAssets)
            {
                asset.WriteAsset();
            }
        }
        
        public void ReadAssetsFromXML()
        {

        }
        public void WriteAssetsToXML()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vecka03Miniproject01
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
                if (Console.ReadLine().Trim().ToLower()[0] == 'q') break; 
                
                var asset = new Asset();
                asset.ReadAsset();
                AllAssets.Add(asset);
            }
            
        }
        public void WriteAssetsToConsole()
        {
            Console.WriteLine(
                "Model Name".PadRight(15) +
                "Purchase Date".PadRight(15) +
                "Local Price".PadRight(15) +
                "Office Location".ToString().PadRight(15)
                );
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

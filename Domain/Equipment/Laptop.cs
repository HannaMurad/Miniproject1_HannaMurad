using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Laptop : Equipment
    {
        public Laptop() : base()
        {
        }
        public Laptop(string modelName, DateTime purchaseDate, decimal purchasePrice) : base(modelName, purchaseDate, purchasePrice)
        {
        }

        public override string GetEquipmentType()
        {
            return "Laptop Computer";
        }
    }
}

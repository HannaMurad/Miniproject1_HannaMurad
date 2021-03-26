using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Mobile : Equipment
    {
        public Mobile() : base()
        {
            
        }

        public Mobile(string modelName, DateTime purchaseDate, decimal purchasePrice) : base(modelName, purchaseDate, purchasePrice)
        {

        }

        public override string GetEquipmentType()
        {
            return "Mobile Phone";
        }
    }
}

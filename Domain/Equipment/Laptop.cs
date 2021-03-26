using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Laptop : Equipment
    {
        public override string GetEquipmentType()
        {
            return "Laptop Computer";
        }
    }
}

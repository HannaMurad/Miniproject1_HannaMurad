using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Desktop : Equipment
    {
        public override string GetEquipmentType()
        {
            return "Desktop PC";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public static class InputAndValidation
    {
        public static void ReadAndValidate(out EquipmentType output, string message)
        {
            output = EquipmentType.Laptop;
            while (true)
            {
                Console.WriteLine(message);
                if (Enum.TryParse(output.GetType(), Console.ReadLine().Trim(), true, out Object result))
                {
                    output = (EquipmentType)result;
                    return;
                }
                else Console.WriteLine("wrong Format");
            }
        }

        public static void ReadAndValidate(out Location output, string message)
        {
            output = Location.UnitedStates;
            while (true)
            {
                Console.WriteLine(message);
                if (Enum.TryParse(output.GetType(), Console.ReadLine().Trim(), true, out Object result))
                {
                    output = (Location)result;
                    return;
                }
                else Console.WriteLine("wrong Format");
            }  
        }

        public static void ReadAndValidate(out string output, string message)
        {
            Console.WriteLine(message);
            output = Console.ReadLine().Trim();
        }

        public static void ReadAndValidate(out decimal output, string message)
        {
            while(true)
            {
                Console.WriteLine(message);
                if (decimal.TryParse(Console.ReadLine().Trim(), out output)) return;
                else Console.WriteLine("Wrong Format");      
            }     
        }

        public static void ReadAndValidate(out int output, string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine().Trim(), out output)) return;
                else Console.WriteLine("Wrong Format");
            }
        }

        public static void ReadAndValidate(out DateTime output, string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                if (DateTime.TryParse(Console.ReadLine().Trim(), out output)) return;
                else Console.WriteLine("Wrong Format");
            }
        }
    }
}

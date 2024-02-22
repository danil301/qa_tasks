using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Auto
{
    public class Bus : Auto
    {
        public int OwnWeight { get; set; }

        public int MaxPassangersAmount { get; set; }

        public int PassangerAmount { get; set; }

        public Bus(string name, int realised, int fuel, int mileage, int averageConsumption, int volume, int maxWeight, int maxPassangersAmount) : base(name, realised, fuel, mileage, averageConsumption, volume, maxWeight)
        {
            OwnWeight = MaxWeight - MaxPassangersAmount * 85;
            MaxPassangersAmount = maxPassangersAmount;
            PassangerAmount = 0;
        }

        public override void FillThings()
        {
            if (PassangerAmount + 10 <= MaxPassangersAmount)
            {
                OwnWeight += 10 * 85;
                PassangerAmount += 10;
                Console.WriteLine("Зашло 10 пассажиров");
            }
            else
            {
                OwnWeight += (MaxPassangersAmount - PassangerAmount) * 85;
                PassangerAmount = MaxPassangersAmount;
                Console.WriteLine($"Зашло {MaxPassangersAmount - PassangerAmount} пассажиров");
            }
        }

        public void FillThings(int amount)
        {
            if (PassangerAmount + amount <= MaxPassangersAmount)
            {
                OwnWeight += amount * 85;
                PassangerAmount += amount;
                Console.WriteLine($"Зашло {amount} пассажиров");
            }
            else
            {
                OwnWeight += (MaxPassangersAmount - PassangerAmount) * 85;
                PassangerAmount = MaxPassangersAmount;
                Console.WriteLine($"Зашло {MaxPassangersAmount - PassangerAmount} пассажиров");
            }
        }
    }
}

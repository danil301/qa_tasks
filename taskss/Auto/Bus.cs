using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Auto
{
    public class Bus : Auto
    {
        private int OwnWeight { get; set; }

        private int MaxPassangersAmount { get; set; }

        private int PassangerAmount { get; set; }

        public Bus(Driver driver, string name, int realised, int fuel, int mileage, int averageConsumption, int volume, int maxWeight, int maxPassangersAmount) 
            : base(driver, name, realised, fuel, mileage, averageConsumption, volume, maxWeight)
        {
            OwnWeight = MaxWeight - MaxPassangersAmount * 85;
            MaxPassangersAmount = maxPassangersAmount;
            PassangerAmount = 0;
        }

        /// <summary>
        /// Заполнение автобуса людьми(10 человек)
        /// </summary>
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

        /// <summary>
        /// Заполнение автобуса людьми
        /// </summary>
        /// <param name="amount">Колличество человек</param>
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
                Console.WriteLine($"Зашло {MaxPassangersAmount - PassangerAmount} пассажиров");
                PassangerAmount = MaxPassangersAmount;
            }
        }

        /// <summary>
        /// Выводит в консоль информацию о текущем количестве пассажиров
        /// </summary>
        public void PrintPassangersAmount() => Console.WriteLine($"В автобусе {PassangerAmount} пассажиров");
    }
}

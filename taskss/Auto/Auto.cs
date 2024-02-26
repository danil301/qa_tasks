using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Auto
{
    public abstract class Auto
    {
        protected Driver Driver { get; set; }

        protected string Name { get; set; }

        protected int Realised { get; set; }

        protected int Fuel { get; set; }

        protected int Mileage { get; set; }

        protected int AverageConsumption { get; set; }

        protected int Volume { get; set; }

        protected int MaxWeight { get; set; }

        protected bool Old
        {
            get
            {
                if (2023 - Realised > 15) return true;
                return false;
            }
        }

        protected Auto(Driver dviver, string name, int realised, int fuel, int mileage, int averageConsumption, int volume, int maxWeight)
        {
            Driver = dviver;
            Name = name;
            Realised = realised;
            Fuel = fuel;
            Mileage = mileage;
            AverageConsumption = averageConsumption;
            Volume = volume;
            MaxWeight = maxWeight;
        }

        /// <summary>
        /// Движение транспорта
        /// </summary>
        /// <param name="way">Расстояние(км.)</param>
        public void Move(int way)
        {
            if (way <= 0) return;
            else if (way > AverageConsumption * Fuel)
            {              
                Mileage += AverageConsumption * Fuel;
                Console.WriteLine($"Бензин закончился. {Name} проехал {AverageConsumption * Fuel} км");
                Fuel = 0;
            }
            else
            {
                Mileage += way;
                Fuel -= way * AverageConsumption;
                Console.WriteLine($"{Name} проехал {way} км");
            }           
        }

        /// <summary>
        /// Вывод информации о транспорте в консоль
        /// </summary>
        public void About()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Название: " + Name);
            Console.WriteLine("Год выпуска: " + Realised);
            Console.WriteLine("Пробег: " + Mileage);
            Console.WriteLine("Потребление бензина: " + AverageConsumption);
            Console.WriteLine("Объем бака: " + Volume);
            Console.WriteLine("Максимальный вес: " + MaxWeight);
            Console.WriteLine("Старый? - " + Old);
            Console.WriteLine("-----------------------------------------");
        }

        /// <summary>
        /// Добавление бензина к транспорту
        /// </summary>
        /// <param name="amount">Колличество бензина(л.)</param>
        public void FillFuel(int amount)
        {
            if (amount * 90 <= Driver.GetMoney())
            {
                Driver.TakeMoney(amount * 90);
                Fuel += amount;
                if (Fuel > Volume) Fuel = Volume;
                Console.WriteLine($"Бак заправлен до {Fuel}л.");
            }
            else Console.WriteLine("У водителя недостаточно денег.");
            
        }

        public virtual void FillThings() => Console.WriteLine("Происходит заполнение автомобиля полезным грузом.");

        /// <summary>
        /// Выводит в консоль количество текущего бензина
        /// </summary>
        public void PrintFuel() => Console.WriteLine($"Осталось {Fuel}л.");
     }
}

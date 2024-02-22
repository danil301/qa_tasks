using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Auto
{
    public abstract class Auto
    {
        protected Auto(string name, int realised, int fuel, int mileage, int averageConsumption, int volume, int maxWeight)
        {
            Name = name;
            Realised = realised;
            Fuel = fuel;
            Mileage = mileage;
            AverageConsumption = averageConsumption;
            Volume = volume;   
            MaxWeight = maxWeight;
        }

        public string Name { get; set; }

        public int Realised { get; set; }

        public int Fuel { get; set; }

        public int Mileage { get; set; }

        public int AverageConsumption { get; set; }

        public int Volume { get; set; }

        public int MaxWeight { get; set; }

        public bool Old
        {
            get
            {
                if (2023 - Realised > 15) return true;
                return false;
            }
        }


        public void Move(int way)
        {
            if (way <= 0) return;

            Mileage += way;
            Fuel -= way * AverageConsumption;

            Console.WriteLine($"{Name} проехал {way} км");
        }

        public void About()
        {
            Console.WriteLine("Название: " + Name);
            Console.WriteLine("Год выпуска: " + Realised);
            Console.WriteLine("Осталось топлива: " + Fuel);
            Console.WriteLine("Пробег: " + Mileage);
            Console.WriteLine("Потребление бензина: " + AverageConsumption);
            Console.WriteLine("Объем бака: " + Volume);
            Console.WriteLine("Максимальный вес: " + MaxWeight);
            Console.WriteLine("Старый? - " + Old);
        }

        public void FillFuel(int amount)
        {
            Fuel += amount;
            if (Fuel > Volume) Fuel = Volume;
        }

        public virtual void FillThings() => Console.WriteLine("Происходит заполнение автомобиля полезным грузом.");
     }
}

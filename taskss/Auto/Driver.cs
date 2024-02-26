using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Auto
{
    public class Driver
    {
        private string Name { get; set; }

        private int Money { get; set; }

        public Driver(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public int GetMoney()
        {
            return Money;
        }

        public void SetMoney(int amount)
        {
            Money += amount;
        }

        public void TakeMoney(int amount)
        {
            Money -= amount;
        }
    }
}

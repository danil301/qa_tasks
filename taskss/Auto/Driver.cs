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

        /// <summary>
        /// Информация о текущем количестве денег
        /// </summary>
        /// <returns>Текущее количество денег</returns>
        public int GetMoney()
        {
            return Money;
        }

        /// <summary>
        /// Добавить денег к текущим
        /// </summary>
        /// <param name="amount">Количество денег</param>
        public void AddMoney(int amount)
        {
            Money += amount;
        }

        /// <summary>
        /// Забрать деньги с текущего количества
        /// </summary>
        /// <param name="amount">Количество денег</param>
        public void TakeMoney(int amount)
        {
            Money -= amount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Diary
{
    public class Diary
    {
        private Student[] _students;
        int cursor;

        public Diary(int capacity)
        {
            cursor = 0;
            _students = new Student[capacity];
        }

        /// <summary>
        /// Запись ученика в дневник
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="branch">Профессия</param>
        /// <param name="rate">Оценка</param>
        public void WriteStudent(string name, string branch, Rate rate)
        {
            if (IsAnyStringEmptyOrWhiteSpace(new string[] { name, branch }))
            {
                Console.WriteLine("Имя и/или профессия не должна(ы) быть пуста(ы)");
                return;
            }

            Student student = new Student()
            {
                Name = name,
                Branch = branch,
                Rate = rate
            };

            if (cursor < _students.Length)
            {
                _students[cursor] = student;
                cursor++;
            }
            else
            {
                Console.WriteLine("Страницы для записи закончились");
            }   
        }

        /// <summary>
        /// Вывод всех студентов в консоль
        /// </summary>
        public void PrintStudents()
        {
            for (int i = 0; i < cursor; i++)
            {
                Console.WriteLine($"Имя: {_students[i].Name}");
                Console.WriteLine($"Профессия: {_students[i].Branch}");
                Console.WriteLine($"Оценка: {(int)_students[i].Rate}");
                Console.WriteLine("-------------------------------------------------");
            }
        }


        public bool IsAnyStringEmptyOrWhiteSpace(string[] strings)
        {
            foreach (var str in strings)
            {
                if (string.IsNullOrWhiteSpace(str)) return true;
            }
            return false;
        }
    }
}

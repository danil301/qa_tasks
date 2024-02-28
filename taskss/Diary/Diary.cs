using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskss.Diary.@enum;

namespace taskss.Diary
{
    public class Diary
    {
        private LoggerCustom _loggerCustom;
        private List<Student> _students;
        private int _length;

        public Diary(int capacity)
        {
            _length = capacity;
            _students = new List<Student>(capacity);
            _loggerCustom = new LoggerCustom("C:/Users/dvory/Desktop/LostButFound/taskss/Diary/logs.txt", "C:/Users/dvory/Desktop/LostButFound/taskss/Screens");
        }

        /// <summary>
        /// Запись ученика в дневник
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="branch">Профессия</param>
        /// <param name="rate">Оценка</param>
        public async Task WriteStudentAsync(string name, string branch, Rate rate)
        {
            if (IsAnyStringEmptyOrWhiteSpace(new string[] { name, branch }))
            {
                Console.WriteLine("Имя и/или профессия не должна(ы) быть пуста(ы)");
                await _loggerCustom.LogAsync("Имя и/или профессия не должна(ы) быть пуста(ы).");
                return;
            }

            Student student = new Student()
            {
                Name = name,
                Branch = branch,
                Rate = rate
            };

            if (_students.Count < _length)
            {
                _students.Add(student);
                await _loggerCustom.LogAsync($"Добавлен студент(номер в журнале {_students.Count - 1}).");
            }
            else
            {
                Console.WriteLine("Страницы для записи закончились");
                await _loggerCustom.LogAsync("Страницы для записи закончились.");
            }   
        }

        /// <summary>
        /// Вывод всех студентов в консоль
        /// </summary>
        public void PrintStudents()
        {
            for (int i = 0; i < _students.Count; i++)
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

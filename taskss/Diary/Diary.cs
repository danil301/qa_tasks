using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Diary
{
    public class Diary
    {
        private Student[] students;
        int cursor;

        public Diary(int capacity)
        {
            cursor = 0;
            students = new Student[capacity];
        }

        public void WriteStudent(string name, string branch, Rate rate)
        {
            Student student = new Student()
            {
                Name = name,
                Branch = branch,
                Rate = rate
            };

            if (cursor < students.Length)
            {
                students[cursor] = student;
                cursor++;
            }
            else
            {
                Console.WriteLine("Страницы для записи закончились");
            }
            
        }

        public void PrintStudents()
        {
            for (int i = 0; i < cursor; i++)
            {
                Console.WriteLine($"Имя: {students[i].Name}");
                Console.WriteLine($"Профессия: {students[i].Branch}");
                Console.WriteLine($"Оценка: {(int)students[i].Rate}");
                Console.WriteLine("-------------------------------------------------");
            }
        }
    }
}

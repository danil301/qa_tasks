﻿using System;
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
        private Student[] _students;
        int cursor;

        public Diary(int capacity)
        {
            cursor = 0;
            _students = new Student[capacity];
            _loggerCustom = new LoggerCustom("C:/Users/dvory/Desktop/LostButFound/taskss/logs.txt");
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

            if (cursor < _students.Length)
            {
                _students[cursor] = student;
                cursor++;
                await _loggerCustom.LogAsync($"Добавлен студент(номер в журнале {cursor - 1}).");
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

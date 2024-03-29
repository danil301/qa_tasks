﻿using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using taskss;
using taskss.Auto;
using taskss.Diary;
using taskss.Diary.@enum;


class Program
{
    public static void Main()
    {
        var a = System.AppContext.GetData("ArbitraryStringSetting");
        LoggerCustom loggerCustom = new LoggerCustom($"{System.AppContext.GetData("pathToLogs")}/logs.txt",
                System.AppContext.GetData("pathToScreens") as string);

        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < 5; i++)
        {
            Thread myThread = new Thread(() =>
            {
                StartTaxi(loggerCustom);
            });
            threads.Add(myThread);
            myThread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join(); // Wait for all threads to complete
        }

        Console.WriteLine("All threads completed.");

        ////дз 2.7
        //int way;
        //int time;
        //int someVariable;

        //Console.Write("Введите путь(км): ");
        //bool wayCheck = int.TryParse(Console.ReadLine(), out way);
        //Console.Write("Введите время(мин): ");
        //bool timeCheck = int.TryParse(Console.ReadLine(), out time);
        //Console.Write("Введите параметр: ");
        //bool someVariableCheck = int.TryParse(Console.ReadLine(), out someVariable);

        //if (wayCheck && timeCheck && someVariableCheck && way >= 1 && time >= 1) Console.WriteLine(taxiPrice(way, time, someVariable, loggerCustom));
        //else
        //{
        //    loggerCustom.LogAsync("Неверный формат заполнения пути и/или времени.");
        //    Console.WriteLine("Неверный формат заполнения пути и/или времени.");
        //}





        ////дз 6.1 абв(Данил вроде говорил немного самых простых тож решать но это не точно)
        //PrintSortedArray(new int[] { 23, 1, 21, 100 });
        //PrintChangedSortedArr(new string[] { "dsfsdv", "cwdd", "sadED", "DCsdds", "cses", "cdCDCSD" });
        //PrintConcatedArrays(new string[] { "dd", "cded", "wdfs" }, new string[] { "dsdff", "fsfvfrsq", "dsds" });

        ////дз 6.3
        //string[] names = new string[] { "Bob", "Jack", "Liza", "Tom", "Jessie", "Maria", "Mark", "Maxim", "Danil", "Sarah" };
        //string[] branches = new string[] { "QA", "Doctor", "Teacher", "Front", "Back", "ML" };
        //Rate[] rates = new Rate[] { Rate.Bad, Rate.Medium, Rate.Good, Rate.Excellent };
        //int n = 10;

        //Diary diary = new Diary(n);
        //for (int i = 0; i < n; i++)
        //{
        //    Random random = new Random();
        //    diary.WriteStudentAsync(names[random.Next(0, names.Length - 1)], branches[random.Next(0, branches.Length - 1)], rates[random.Next(0, rates.Length - 1)]);  
        //}
        //diary.WriteStudentAsync("", "", Rate.Bad);
        //diary.WriteStudentAsync("Лишний", "a", Rate.Medium);
        //diary.PrintStudents();



        ////дз 8.3
        //// todo сделать грузовик, подумать что нужно добавить ещё
        //var driver = new Driver("Mike", 100000);
        //var name = "Автобус";
        //var realised = 2000;
        //var fuel = 15;
        //var mileage = 100000;
        //var averageConsumption = 5;
        //var volume = 100;
        //var maxWeight = 1500;
        //var maxPassangersAmount = 20;

        //Bus bus = new Bus(driver, name, realised, fuel, mileage, averageConsumption, volume, maxWeight, maxWeight);
        //bus.About();
        //bus.FillFuel(20);
        //bus.Move(1000);
        //bus.PrintFuel();
        //bus.FillThings(199);
        //bus.PrintPassangersAmount();
    }

    public static void StartTaxi(LoggerCustom loggerCustom)
    {
        for (int j = 0; j < 2; j++)
        {
            Random rnd = new Random();
            int way = rnd.Next(1, 100);
            int time = rnd.Next(1, 100);
            int someVariable = rnd.Next(1, 100);

            taxiPrice(way, time, someVariable, loggerCustom);
        }
    }

    public static int taxiPrice(int way, int time, int someVariable, LoggerCustom loggerCustom)
    {
        try
        {
            var price = Math.Max(30 * way, 40 * time) / someVariable;
            loggerCustom.LogAsync($"Сумма поездки {price}");
            return price;
        }
        catch (Exception ex)
        {
            loggerCustom.LogAsync(ex.Message);
            Console.WriteLine(ex.Message);
            return 0;
        }
    }

    public static void PrintSortedArray(int[] arr)
    {
        Array.Sort(arr);
        var str = string.Join(" ", arr);
        Console.WriteLine(str);
    }

    public static void PrintChangedSortedArr(string[] arr)
    {
        if (arr.Length > 0) arr[0] = RandomString();
        if (arr.Length > 1) arr[1] = RandomString();
        if (arr.Length > 2) arr[2] = RandomString();

        Array.Sort(arr);
        var str = string.Join(" ", arr);
        Console.WriteLine(str);
    }

    public static string RandomString()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int len = random.Next(1, 20);

        string str = string.Empty;
        for (int i = 0; i < len; i++) str += chars[random.Next(0, chars.Length - 1)];

        return str;
    }

    public static void PrintConcatedArrays(string[] arr1, string[] arr2)
    {
        List<string> list = new List<string>();
        list.AddRange(arr1);
        list.AddRange(arr2);
        string[] arr3 = list.ToArray();

        var str = string.Join(" ", arr3);
        Console.WriteLine(str);
    }


}
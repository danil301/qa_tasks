using taskss.Auto;
using taskss.Diary;

// для задания с авто нужно ещё подумать над исключительными и нелогическими случаями, которые не прописаны в задании и сделать грузовик

class Program
{
    public static void Main()
    {
        //дз 2.7
        //Console.Write("Введите путь(км): ");
        //int way = int.Parse(Console.ReadLine());
        //Console.Write("Введите время(мин): ");
        //int time = int.Parse(Console.ReadLine());
        //Console.WriteLine(taxiPrice(way, time));

        //дз 6.1 абв (Данил вроде говорил немного самых простых тож решать но это не точно)
        //PrintSortedArray(new int[] { 23, 1, 21, 100 });
        //PrintChangedSortedArr(new string[] { "dsfsdv", "cwdd", "sadED", "DCsdds", "cses", "cdCDCSD" });
        //PrintConcatedArrays(new string[] { "dd", "cded", "wdfs" }, new string[] { "dsdff", "fsfvfrsq", "dsds" });

        ////дз 6.3
        //Diary diary = new Diary(10);
        //diary.WriteStudent("Bob", "QA", Rate.Medium);
        //diary.WriteStudent("Jack", "Doctor", Rate.Bad);
        //diary.WriteStudent("Liza", "Teacher", Rate.Exccelent);
        //diary.WriteStudent("Tom", "ML", Rate.Medium);
        //diary.WriteStudent("Jessie", "Back", Rate.Bad);
        //diary.WriteStudent("Maria", "Front", Rate.Exccelent);
        //diary.WriteStudent("Mark", "Teacher", Rate.Exccelent);
        //diary.WriteStudent("Maxim", "ML", Rate.Medium);
        //diary.WriteStudent("Danil", "Back", Rate.Bad);
        //diary.WriteStudent("Sarah", "Front", Rate.Exccelent);

        //diary.PrintStudents();


        
        //дз 8.3
        // todo сделать грузовик, подумать что нужно добавить еще, сделать у класса авто поля protected
        Bus bus = new Bus(new Driver("Mike", 100000), "Автобус", 2000, 10, 100000, 5, 100, 1500, 20);
        bus.About();
        bus.FillFuel(20);
        bus.Move(1000);
        //bus.About();
        bus.FillThings(199);
    }

    public static int taxiPrice(int way, int time)
    {
        return Math.Max(30 * way, 40 * time);
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
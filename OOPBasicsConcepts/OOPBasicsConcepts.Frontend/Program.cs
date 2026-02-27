using OOPBasicsConcepts.Backend;
using System.Text.RegularExpressions;


internal class Program
{
    private static void Main(string[] args)
    { 
        Time t1 = new Time();
        Time t2 = new Time(14);
        Time t3 = new Time(9, 34);
        Time t4 = new Time(19, 45, 56);
        Time t5 = new Time(23, 3, 45, 678);

        Time[] times = { t1, t2, t3, t4, t5 };

        foreach (Time t in times)

        {
            Console.WriteLine($"Time: {t}");
            Console.WriteLine($"        Milliseconds: {t.ToMilliseconds().ToString("N0"),15}");
            Console.WriteLine($"        Seconds     :   {t.ToSeconds().ToString("N0"),13}");
            Console.WriteLine($"        Minutes     :   {t.ToMinutes().ToString("N0"),13}");
            Console.WriteLine($"        Add         : {t.Add(t3)}");
            Console.WriteLine($"        Is Other day: {t.IsOtherDay(t4)}");
            Console.WriteLine();
        }

        try
        {
            Time invalid = new Time(45);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"The hour: 45, is not valid.");
        }
    }
}
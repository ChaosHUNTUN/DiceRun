// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

object Locker = new object();
object Locker2 = new object();
Dictionary<string, int> list = new Dictionary<string, int>();
Dictionary<string, int> list2 = new Dictionary<string, int>();
int temp = 0;
int temp2 = 0;
Random rd = new Random();
//创建一个1到24的int数组
Task.Run(() =>
{
    while (temp <= 10000)
    {
        DiceHepler.CreateNewStrings();
        DiceHepler.indexNum.Clear();
        DiceHepler.isUpSure = false;
        DiceHepler.isRightSure = false;
        int c = rd.Next(1, 24);
        DiceHepler.UpSide = c % 6;

        DiceHepler.RightSide = c / 6;
        string result = DiceHepler.isYING(DiceHepler.UpSide) + DiceHepler.isYING(DiceHepler.FrontSide) + DiceHepler.isYING(DiceHepler.RightSide);
        if (result == "001")
            result = "100";
        if (result == "011")
            result = "110";
        if (result == "010")
            result = "100";
        if (result == "101")
            result = "110";
        lock (Locker)
        {

            if (list.ContainsKey(result))
            {
                list[result]++;
            }
            else
            {
                list.Add(result, 1);
            }
            temp++;
        }
        Thread.Sleep(10);
    }

});
Task.Run(() =>
{
    while (temp2 < 10000)
    {
        var s = rd.Next(0, 4);
        var a = s >= 3 ? 1 : 0;
        var b = s >= 2 ? 1 : 0;
        var c = s >= 1 ? 1 : 0;

        string result = a + "" + b + "" + c;
        if (result == "001")
            result = "100";
        if (result == "011")
            result = "110";
        if (result == "010")
            result = "100";
        if (result == "101")
            result = "110";


        lock (Locker2)
        {


            if (list2.ContainsKey(result))
            {
                list2[result]++;
            }
            else
            {
                list2.Add(result, 1);
            }
            temp2++;
        }
    }

});



while (true)
{
    Console.WriteLine("list1:");
    lock (Locker)
        foreach (var a in list)
        {
            double rs = Math.Round((double)(a.Value / (double)temp), 7);
            Console.WriteLine(a.Key + ":" + (rs).ToString("0%"));
        }
    Console.WriteLine();
    Console.WriteLine("list2:");
    lock (Locker2)
        foreach (var a in list2)
        {
            double rs = Math.Round((double)(a.Value / (double)temp2), 7);
            Console.WriteLine(a.Key + ":" + (rs).ToString("0%"));
        }
    Console.WriteLine();
    Thread.Sleep(5000);
}
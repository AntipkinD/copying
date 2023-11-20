using System;
using System.IO;
internal class Program
{
    private static void Copy1()
    {
        string src = @"D:\file0.txt";
        string dest = @"D:\file.txt";
        File.Copy(src, dest, true);
    }
    private static void Copy2()
    {
        string src = @"D:\file01.txt";
        string dest = @"D:\file1.txt";
        File.Copy(src, dest, true);
    }
    internal class Timer
    {
        public DateTime dt1;
        public DateTime dt2;
        public Timer() /// Конструктор создаёт таймер вызывать так: Timer timer = new Timer();
        {

        }
        public void Start() /// запускает таймер вызывать так: timer.Start();
        {
            dt1 = DateTime.Now;
        }
        public void Stop() /// останавливает таймер и выводит сколько времени прошло с начала запуска вызывать так: Timer.Stop();
        {
            dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            Console.WriteLine("Времени прошло " + ts.TotalMilliseconds + " миллисекунда"); /// время отоброжается в миллисекундах
        }
    }
    private static void Main(string[] args)
    {
        string state = Console.ReadLine();
        if (state == "parallel")
        {
            Thread copy1 = new(Copy1);
            Thread copy2 = new(Copy2);
            Timer timer = new Timer();
            timer.Start();
            copy1.Start();
            copy2.Start();
            timer.Stop();
        }
        if (state == "subseq")
        {
            Thread copy1 = new(Copy1);
            Thread copy2 = new(Copy2);
            Timer timer = new Timer();
            timer.Start();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0) copy1.Start();
                if (i == 1) copy2.Start();
            }
            timer.Stop();
        }
    }
}
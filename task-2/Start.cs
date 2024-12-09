class Start_MyTime
{
    public static void StartMyTime(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть години:");
        int hours = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть хвилини:");
        int minutes = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть секунди:");
        int seconds = int.Parse(Console.ReadLine());

        MyTime currentTime = new MyTime(hours, minutes, seconds);
        Console.WriteLine($"Поточний час: {currentTime}");

        Console.WriteLine("Введіть кількість секунд, які треба додати:");
        int addSeconds = int.Parse(Console.ReadLine());
        MyTime newTime = currentTime.AddSeconds(addSeconds);
        Console.WriteLine($"Новий час: {newTime}");

        string currentLesson = newTime.WhatLesson(); 
        Console.WriteLine($"Поточна пара: {currentLesson}");

        int secondsSinceMidnight = currentTime.ToSecSinceMidnight();
        Console.WriteLine($"Кількість секунд з початку доби: {secondsSinceMidnight}");

        MyTime timeFromSeconds = new MyTime(0, 0, 0);
        timeFromSeconds.FromSecSinceMidnight(secondsSinceMidnight);
        Console.WriteLine($"Час з кількості секунд з початку доби: {timeFromSeconds}");

        MyTime timeFromSecond = new MyTime(0, 0, 0);
        MyTime newSecondTime = timeFromSecond.AddSeconds(-65);
        Console.WriteLine($"New Time: {newSecondTime}");
    }
}



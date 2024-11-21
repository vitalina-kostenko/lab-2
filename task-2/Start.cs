using System;

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

        MyTime nextHour = currentTime.AddOneHour();
        Console.WriteLine($"Час через годину: {nextHour}");

        MyTime nextLessonStart = new MyTime(23, 59, 59);
        bool isInRange = nextLessonStart.IsInRange(new MyTime(6, 0, 0), new MyTime(0, 0, 1));
        Console.WriteLine($"Чи поточний час в діапазоні між поточним часом та початком наступної пари: {isInRange}");

        string currentLesson = currentTime.WhatLesson();
        Console.WriteLine($"Поточна пара: {currentLesson}");

        int secondsSinceMidnight = currentTime.ToSecSinceMidnight();
        Console.WriteLine($"Кількість секунд з початку доби: {secondsSinceMidnight}");

        MyTime timeFromSeconds = new MyTime(0, 0, 0);
        timeFromSeconds.FromSecSinceMidnight(secondsSinceMidnight);
        Console.WriteLine($"Час з кількості секунд з початку доби: {timeFromSeconds}");

        MyTime timeFromSecond = new MyTime(0, 0, 0);
        MyTime newTime = timeFromSecond.AddSeconds(-86405);
        Console.WriteLine($"New Time: {newTime}");
    }
}



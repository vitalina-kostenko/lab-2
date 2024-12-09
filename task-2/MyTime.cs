public class MyTime
{
    public int Hour { get; private set; }
    public int Minute { get; private set; }
    public int Second { get; private set; }

    public MyTime(int h, int m, int s)
    {
        FromSecSinceMidnight(h * 3600 + m * 60 + s);
    }

    public override string ToString()
    {
        return $"{Hour:D2}:{Minute:D2}:{Second:D2}";
    }

    public int ToSecSinceMidnight()
    {
        return Hour * 3600 + Minute * 60 + Second;
    }

    public void FromSecSinceMidnight(int t)
    {
        int secPerDay = 24 * 3600;
        t = ((t % secPerDay) + secPerDay) % secPerDay; 
        Hour = t / 3600;
        Minute = (t / 60) % 60;
        Second = t % 60;
    }

    public MyTime AddSeconds(int s)
    {
        int totalSeconds = ToSecSinceMidnight() + s;
        MyTime result = new MyTime(0, 0, 0);
        result.FromSecSinceMidnight(totalSeconds);
        return result;
    }

    public MyTime AddOneSecond()
    {
        return AddSeconds(1);
    }

    public MyTime AddOneMinute()
    {
        return AddSeconds(60);
    }

    public MyTime AddOneHour()
    {
        return AddSeconds(3600);
    }

    public int Difference(MyTime mt)
    {
        return this.ToSecSinceMidnight() - mt.ToSecSinceMidnight();
    }

    public bool IsInRange(MyTime start, MyTime finish)
    {
        int startSec = start.ToSecSinceMidnight();
        int finishSec = finish.ToSecSinceMidnight();
        int tSec = this.ToSecSinceMidnight();

        if (startSec <= finishSec)
        {
            return tSec >= startSec && tSec <= finishSec;
        }
        else
        {
            return tSec >= startSec || tSec <= finishSec;
        }
    }

    public string WhatLesson()
    {
        MyTime[] lessonStarts = {
            new MyTime(8, 0, 0),    // Початок першої пари
            new MyTime(9, 40, 0),   // Початок другої пари
            new MyTime(11, 20, 0),  // Початок третьої пари
            new MyTime(13, 0, 0),   // Початок четвертої пари
            new MyTime(14, 40, 0),  // Початок п'ятої пари
            new MyTime(16, 20, 0)   // Початок шостої пари
        };

        MyTime[] lessonEnds = {
            new MyTime(9, 20, 0),   // Кінець першої пари
            new MyTime(11, 0, 0),   // Кінець другої пари
            new MyTime(12, 40, 0),  // Кінець третьої пари
            new MyTime(14, 20, 0),  // Кінець четвертої пари
            new MyTime(16, 0, 0),   // Кінець п'ятої пари
            new MyTime(17, 40, 0)   // Кінець шостої пари
        };

        for (int i = 0; i < lessonStarts.Length; i++)
        {
            if (this.IsInRange(lessonStarts[i], lessonEnds[i]))
            {
                return $"{i + 1}-а пара";
            }

            if (i < lessonStarts.Length - 1 && this.IsInRange(lessonEnds[i], lessonStarts[i + 1]))
            {
                return $"Перерва між {i + 1}-ю та {i + 2}-ю парами";
            }
        }

        if (this.IsInRange(lessonEnds[^1], lessonStarts[0]))
            return "Пари вже скінчилися";

        return "Пари ще не почалися";
    }
}

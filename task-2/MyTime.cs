public class MyTime
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }

    public MyTime(int h, int m, int s)
    {
        Hour = h;
        Minute = m;
        Second = s;
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
        int secPerDay = 60 * 60 * 24;
        t %= secPerDay;
        if (t < 0)
            t += secPerDay;
        Hour = t / 3600;
        Minute = (t / 60) % 60;
        Second = t % 60;
    }

    public MyTime AddOneSecond()
    {
        int totalSeconds = ToSecSinceMidnight() + 1;
        MyTime result = new MyTime(0, 0, 0);
        result.FromSecSinceMidnight(totalSeconds);
        return result;
    }

    public MyTime AddOneMinute()
    {
        int totalSeconds = ToSecSinceMidnight() + 60;
        MyTime result = new MyTime(0, 0, 0);
        result.FromSecSinceMidnight(totalSeconds);
        return result;
    }

    public MyTime AddOneHour()
    {
        int totalSeconds = ToSecSinceMidnight() + 3600;
        MyTime result = new MyTime(0, 0, 0);
        result.FromSecSinceMidnight(totalSeconds);
        return result;
    }

    public MyTime AddSeconds(int s)
    {
        int totalSeconds = ToSecSinceMidnight() + s;
        MyTime result = new MyTime(0, 0, 0);
        result.FromSecSinceMidnight(totalSeconds);
        return result;
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
            if (startSec <= tSec && tSec <= finishSec) return true;

            else return false;

        }
        else
        {
            if (tSec >= startSec || tSec <= finishSec) return true;

            else return false;
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
            if (this.Hour < lessonStarts[i].Hour || (this.Hour == lessonStarts[i].Hour && this.Minute < lessonStarts[i].Minute))
            {
                if (i == 0)
                    return "Пари ще не почалися";
                else
                    return $"Перерва між {i}-ю та {i + 1}-ю парами";
            }
            else if ((this.Hour == lessonStarts[i].Hour && this.Minute == lessonStarts[i].Minute) ||
                     (this.Hour == lessonEnds[i].Hour && this.Minute == lessonEnds[i].Minute))
            {
                return $"{i + 1}-а пара";
            }
        }

        return "Пари вже скінчилися";
    }
}

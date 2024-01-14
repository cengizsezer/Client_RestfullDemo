using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeUtil
{
   

    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }

    public static float CalculateDifferenceTime(DateTime startTime, DateTime endTime)
    {
        TimeSpan difference = startTime - endTime;
        return (float)difference.TotalMinutes;
    }

    public static float GetDifferenceTime(DateTime startTime, DateTime endTime)
    {
        TimeSpan difference = endTime - startTime;
        return (float)difference.TotalSeconds;
    }


    public static string FormatTime(float minutes)
    {
        int hours = (int)minutes / 60;
        int remainingMinutes = (int)minutes % 60;

        if (remainingMinutes == 0)
        {
            return $"{hours}h 00m";
        }
        else if (hours == 0)
        {
            return $"{remainingMinutes}m";
        }
        else
        {
            return $"{hours}h {remainingMinutes}m";
        }
    }

    public static string ConvertUnixToMonthYear(long date)
    {
        DateTime userCreateTime;

        // Eğer date, milisaniye cinsinden bir Unix zaman damgasıysa
        if (date > 9999999999) // Bu kontrol, date'nin saniye mi yoksa milisaniye mi olduğunu anlamak için basit bir yöntemdir
        {
            userCreateTime = DateTimeOffset.FromUnixTimeMilliseconds(date).DateTime;
        }
        else
        {
            userCreateTime = DateTimeOffset.FromUnixTimeSeconds(date).DateTime;
        }

        return userCreateTime.ToString("MM/yyyy");
    }


    public static string FormatTimeWithDay(float minutes)
    {
        int days = (int)minutes / 1440; // 60*24
        int minutesAfterDays = (int)minutes % 1440;

        int hours = minutesAfterDays / 60;

        if (days > 0)
        {
            if (hours > 0)
            {
                return $"{days}d {hours}h";
            }

            if (hours == 0)
            {
                if (days == 1)
                {
                    return $"{days} day";
                }
                else
                {
                    return $"{days} days";
                }
            }
        }

        return null;
    }

    public static string FormatTimeWithSeconds(float minutes)
    {
        int totalSeconds = (int)(minutes * 60);

        int hours = totalSeconds / 3600;
        int remainingMinutes = (totalSeconds % 3600) / 60;
        int remainingSeconds = totalSeconds % 60;

        if (hours > 0)
        {
            if (remainingMinutes > 0 && remainingSeconds > 0)
            {
                return $"{hours}h {remainingMinutes}m {remainingSeconds}s";
            }
            else if (remainingMinutes > 0)
            {
                return $"{hours}h {remainingMinutes}m";
            }
            else if (remainingSeconds > 0)
            {
                return $"{hours}h {remainingSeconds}s";
            }
            else
            {
                return $"{hours}h";
            }
        }
        else if (remainingMinutes >= 60)
        {
            return $"{remainingMinutes}m";
        }
        else if (remainingMinutes > 0)
        {
            if (remainingSeconds > 0)
            {
                return $"{remainingMinutes}m {remainingSeconds}s";
            }
            else
            {
                return $"{remainingMinutes}m";
            }
        }
        else
        {
            return $"{remainingSeconds}s";
        }
    }
    

    private static string SetRemainingTimeText(float remainingTime)
    {
        if (remainingTime > 1440)
        {
            return FormatTimeWithDay(remainingTime);
        }

        if (remainingTime <= 1440)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime * 60);

            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        return "";
    }
}

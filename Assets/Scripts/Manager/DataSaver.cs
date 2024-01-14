using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataSaver
{
    public static string Token;
    public static void SetData<T>(string key, T value)
    {
        if (typeof(T) == typeof(int))
        {
            PlayerPrefs.SetInt(key, (int)(object)value);
        }
        else if (typeof(T) == typeof(string))
        {
            PlayerPrefs.SetString(key, (string)(object)value);
        }
        else if (typeof(T) == typeof(bool))
        {
            int data = ConvertBoolToInt((bool)(object)value);
            PlayerPrefs.SetInt(key, data);
        }
        else
        {
            Debug.LogError("Unsupported data type.");
        }
    }

    public static T GetData<T>(string key, T defaultValue = default)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
        }
        else if (typeof(T) == typeof(string))
        {
            return (T)(object)PlayerPrefs.GetString(key, (string)(object)defaultValue);
        }
        else if (typeof(T) == typeof(bool))
        {
            int data = ConvertBoolToInt((bool)(object)defaultValue);
            data = PlayerPrefs.GetInt(key, data);
            return (T)(object)ConvertIntToBool(data);
        }
        else
        {
            Debug.LogError("Unsupported data type.");
            return defaultValue;
        }
    }

    public static bool HasKey(string KeyName)
    {
        if (PlayerPrefs.HasKey(KeyName))
        {
            return true;
        }

        return false;
    }

    private static int ConvertBoolToInt(bool booleanValue)
    {
        return booleanValue ? 1 : 0;
    }

    private static bool ConvertIntToBool(int integerValue)
    {
        return integerValue != 0;
    }
}

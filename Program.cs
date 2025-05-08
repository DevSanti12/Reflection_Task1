using System;
using System.Runtime;
using Reflection;

class Program
{
    static void Main(string[] args)
    {
        MySettings settings = new MySettings();

        // Load settings
        settings.LoadSettings();
        Console.WriteLine($"SettingOne: {settings.SettingOne}");
        Console.WriteLine($"SettingTwo: {settings.SettingTwo}");

        // Modify settings
        settings.SettingOne = 42;
        settings.SettingTwo = "Hello, World!";

        Console.WriteLine($"SettingOne Modified: {settings.SettingOne}");
        Console.WriteLine($"SettingTwo Modified: {settings.SettingTwo}");

        // Save settings
        settings.SaveSettings();
        Console.WriteLine("Settings saved.");
    }
}
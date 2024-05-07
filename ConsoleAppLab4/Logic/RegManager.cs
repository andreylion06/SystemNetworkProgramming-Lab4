using Microsoft.Win32;
using System.Diagnostics;


// Ім'я файлу: RegManager.cs
// Ремарка: RegManager - клас, що включає логіку взаємодії з реєстром Windows
// Автор: Андрій Сахно

namespace ConsoleAppLab4.Logic
{
    public class RegManager
    {
        // Програмно, вивести список усіх програм та служб які завантажуються
        // автоматично для усіх користувачів та поточного користувача.
        public void ListStartupPrograms(bool forAllUsers)
        {
            Console.WriteLine($"~ Listing startup programs for {(forAllUsers ? "all users" : "current user")}:");

            RegistryKey baseKey;
            if (forAllUsers)
                baseKey = Registry.LocalMachine;
            else
                baseKey = Registry.CurrentUser;

            using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false))
            {
                if (key != null)
                {
                    foreach (string subkeyName in key.GetValueNames())
                    {
                        object? keyValue = key.GetValue(subkeyName);
                        if (keyValue != null)
                        {
                            string value = keyValue.ToString()!;
                            Console.WriteLine($"Program: {subkeyName}, Path: {value}");
                        }
                    }
                }
            }
        }

        // Додати програмно до автозавантаження програм для поточного
        // користувача завантаження програми WinWord або іншої.
        public void AddProgramToCurrentUserStartup(string programName, string programPath)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (key != null)
                {
                    key.SetValue(programName, programPath);
                    Console.WriteLine($"Program '{programName}' added to current user's startup.");
                }
                else
                {
                    Console.WriteLine("Error accessing registry key.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Зробити програмно копію будь якого розділу реєстру
        // у файл відповідного формату .reg
        public void ExportRegistryKey(string key, string outputFile)
        {
            Process.Start("regedit.exe", $"/E {outputFile} {key}");
        }

    }
}

// Кінець файлу
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Ім'я файлу: Program.cs
// Ремарка: RegManagerTest використовує клас RegManager та створений
//          для його тестування та передачі методів як Action делегатів
//          у елементи меню
// Автор: Андрій Сахно

namespace ConsoleAppLab4.Logic
{
    public class RegManagerTest
    {
        private readonly RegManager _regManager;
        public RegManagerTest()
        {
            _regManager = new RegManager();
        }

        public void ListStartupProgramsAllUsers()
        {
            _regManager.ListStartupPrograms(true);
        }

        public void ListStartupProgramsCurrentUser()
        {
            _regManager.ListStartupPrograms(false);
        }

        public void AddSpotifyToCurrentUserStartup()
        {
            string programName = "Spotify";
            string programPath = @"C:\Users\User\AppData\Roaming\Spotify\Spotify.exe";


            _regManager.AddProgramToCurrentUserStartup(programName, programPath);
        }

        public void TestExportRegistryKey()
        {
            string key = @"HKEY_CURRENT_USER\SOFTWARE\TestLab4";
            string outputFilePath = "C:\\Users\\User\\Desktop\\key.reg";

            try
            {
                _regManager.ExportRegistryKey(key, outputFilePath);
                Console.WriteLine($"Registry key exported successfully: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

// Кінець файлу
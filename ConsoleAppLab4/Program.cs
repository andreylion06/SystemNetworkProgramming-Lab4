using ConsoleAppLab4.Logic;

// Ім'я файлу: Program.cs
// Ремарка: Program.cs використовує класи Menu, RegManagerTest,
//          TaskServiceManager та демонструє правильність їх роботи 
// Автор: Андрій Сахно

var regManagerTest = new RegManagerTest();
var taskServiceManager = new TaskServiceManager();

var items = new Dictionary<string, Action>
    {
        { "Listing startup programs for all users", () => regManagerTest.ListStartupProgramsAllUsers() },
        { "Listing startup programs for current user", () => regManagerTest.ListStartupProgramsCurrentUser() },
        { "Add Spotify to current user startup", () => regManagerTest.AddSpotifyToCurrentUserStartup() },
        { "Display all user tasks", () => taskServiceManager.DisplayAllUserTasks() },
        { "Display current user tasks", () => taskServiceManager.DisplayCurrentUserTasks() },
        { "Make copy of test registry key", () => regManagerTest.TestExportRegistryKey() },
        { "Exit", () => { Console.WriteLine("Exiting the program"); Environment.Exit(0); } }
    };

var menu = new Menu(items);

while (true)
{
    menu.DisplayOptions();
    string? option = menu.ChooseOption();
    menu.HandleInput(option);
    menu.WaitNextIteration();
}

// Кінець файлу
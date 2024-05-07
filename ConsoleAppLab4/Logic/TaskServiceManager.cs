using Microsoft.Win32.TaskScheduler;
using System.Threading.Tasks;

// Ім'я файлу: TaskServiceManager.cs
// Ремарка: TaskServiceManager надає інформацію про задачі, зареєстровані
//          у планувальнику задач
// Автор: Андрій Сахно

namespace ConsoleAppLab4.Logic
{
    public class TaskServiceManager
    {
        // Вивести список усіх завдань, які зареєстровані у планувальнику
        // задач системи. Інформації отримати з відповідного розділу реєстру,
        // як для усіх користувачів так і для поточного користувача.
        public void DisplayAllUserTasks()
        {
            using (TaskService ts = new TaskService())
            {
                foreach (Microsoft.Win32.TaskScheduler.Task task in ts.AllTasks)
                {
                    DisplayTask(task);
                }
            }
        }

        public void DisplayCurrentUserTasks()
        {
            using (TaskService ts = new TaskService())
            {
                string userSID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;

                foreach (Microsoft.Win32.TaskScheduler.Task task in ts.FindAllTasks(t => t.Definition.Principal.UserId == userSID || t.Definition.Principal.UserId == null))
                {
                    DisplayTask(task);
                }
            }
        }

        private void DisplayTask(Microsoft.Win32.TaskScheduler.Task task)
        {
            Console.WriteLine("Task Name: " + task.Name);
            Console.WriteLine("Task Path: " + task.Path);
            Console.WriteLine("Task State: " + task.State);
            Console.WriteLine("Task Last Run Time: " + task.LastRunTime);
            Console.WriteLine("Task Next Run Time: " + task.NextRunTime);
            Console.WriteLine("---------------------------------------");
        }
    }
}

// Кінець файлу
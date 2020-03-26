using System;
using System.Collections.Generic;
using DailyTaskListApp.Model;

namespace DailyTaskListApp.ConsoleApp
{
    class Program
    {
        private const string DIVIDER = "---------";
        private static DailyTaskList dailyTaskList;

        static void Main(string[] args)
        {
            // Always loop back to the main menu
            while (true)
            {
                mainMenu();
            }
        }

        static void mainMenu() {
            string[] menuChoices = new String[] { "Generate Today's Tasks List", "Exit" };
            int myChoice = -1;
            bool isValidNumber = false;

            while(true){
                Console.WriteLine("MAIN MENU");
                Console.WriteLine(DIVIDER);
                for (int i = 0; i < menuChoices.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + menuChoices[i]);
                }

                Console.Write("Make a choice: ");
                isValidNumber = int.TryParse(Console.ReadLine(), out myChoice);
                myChoice--;

                if (isValidNumber && myChoice >= 0 && myChoice < menuChoices.Length) {
                    break;
                }
            }

            writeBlankLine();

            if (myChoice == 0)
            {
                generateTasksList();
                displayTasksList();
            }
            else if (myChoice == 1) {
                exit();
            }
            
        }

        private static void exit()
        {
            writeBlankLine();
            Environment.Exit(0);
        }

        private static void displayTasksList()
        {
            if (dailyTaskList == null) {
                Console.WriteLine("No daily tasks list is available.");
                return;
            }

            Console.WriteLine(dailyTaskList.Date);
            Console.WriteLine(DIVIDER);
            for (int i = 0; i < dailyTaskList.NumberOfTasks; i++)
            {
                Console.WriteLine(dailyTaskList[i].StartTimeString + " " + dailyTaskList[i].Description);
            }

            writeBlankLine();
        }

        private static void generateTasksList() {
            DateTime startDate = DateTime.Today;
            TimeSpan startTime = new TimeSpan(8, 0, 0);
            dailyTaskList = new DailyTaskList(startDate, startTime);

            int myChoice = -1;
            bool isValidNumber = false;

            while (true)
            {
                Console.Write("How many half-hour segments? ");

                isValidNumber = int.TryParse(Console.ReadLine(), out myChoice);

                if (isValidNumber && myChoice > 0 && myChoice <= 48)
                {
                    break;
                }
            }

            dailyTaskList.Generate<TaskItem>(myChoice);
        }

        private static void writeBlankLine() {
            Console.WriteLine(String.Empty);
        }
    }
}

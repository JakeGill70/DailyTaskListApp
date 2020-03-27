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
            // WARNING: This code assumes that the user will usually enter correct input
            //      on their first attempt. As such, the menuChoices dictionary is 
            //      populated at the same time they are printed to the console.
            //      This keeps the code performant as it only loops through the
            //      menuAction's keys once. However, this could cause problems down the 
            //      road if user typically enters incalid input, as the menuChoices
            //      dictionary has to be populated menu times over.

            int myChoice = -1;  // User Inputted number
            bool isValidNumber = false; // Is the user inputted number valid?
            // Maps numbers to menu options
            Dictionary<int, string> menuChoices = new Dictionary<int, string>();
            // Maps menu options to actions that the program can do
            Dictionary<string, Action> menuActions = new Dictionary<string, Action>();  
            // Add Menu options as pairs of text to display and the action to take
            menuActions.Add("Generate Today's Task List", new Action( () => { generateTasksList(); displayTasksList(); }));
            menuActions.Add("Exit", new Action( () => { exit(); }));

            // Loop until the user has provided valid input
            while (!isValidNumber){
                Console.WriteLine("MAIN MENU");
                Console.WriteLine(DIVIDER);

                int menuChoicesIndex = 0; // Reset the indexer used to bridge menu choices to menu actions
                foreach (string menuChoice in menuActions.Keys)
                {
                    menuChoicesIndex++; // Increase the index
                    menuChoices[menuChoicesIndex] = menuChoice; // Assign that menu choice to that number
                    Console.WriteLine(menuChoicesIndex + ". " + menuChoice); // Display the number to perform the action
                }

                Console.Write("Make a choice: ");
                // Get User input
                isValidNumber = int.TryParse(Console.ReadLine(), out myChoice); 
                // Validate user input
                // isValidNumber is set to either true or false depending on if the parsing was successful.
                // So, we want to make sure that isValidNumber is false if the user didn't even enter a number.
                // The other validation check is to make sure that the number maps to a menu choice.
                isValidNumber = isValidNumber && menuChoices.ContainsKey(myChoice);
            }

            writeBlankLine();

            // Invoke the selected action
            menuActions[menuChoices[myChoice]].Invoke();
            
        }

        private static void exit()
        {
            writeBlankLine();
            Environment.Exit(0);
        }

        private static void displayTasksList()
        {
            // Cannot display the dailyTaskList if it is not initialized yet.
            if (dailyTaskList == null) {
                Console.WriteLine("No daily tasks list is available.");
                return;
            }

            Console.WriteLine(dailyTaskList.Date);
            Console.WriteLine(DIVIDER);
            // Display each task inside of dailyTaskList
            for (int i = 0; i < dailyTaskList.NumberOfTasks; i++)
            {
                Console.WriteLine(dailyTaskList[i].StartTimeString + " " + dailyTaskList[i].Description);
            }

            writeBlankLine();
        }

        private static void generateTasksList() {
            // Create a new dailyTaskList, starting today at 8:00am
            DateTime startDate = DateTime.Today;
            TimeSpan startTime = new TimeSpan(8, 0, 0);
            dailyTaskList = new DailyTaskList(startDate, startTime);

            int numberOfSegments = -1; // The number of segments requested by the user
            bool isValidNumber = false; // If the number of segments requested is valid

            while (!isValidNumber)
            {
                Console.Write("How many half-hour segments? ");

                // Get user input
                isValidNumber = int.TryParse(Console.ReadLine(), out numberOfSegments);
                // Validate user input
                // isValidNumber is set to either true or false depending on if the parsing was successful.
                // So, we want to make sure that isValidNumber is false if the user didn't even enter a number.
                // The next validation check is to ensure that the user requested at least 1 segment.
                // The final validation check is to limit the number of possible segments to 48.
                // It must be constrainted to 48 because that is the maximum number of 30-minute segments within a day (24hr).
                isValidNumber = isValidNumber && numberOfSegments > 0 && numberOfSegments <= 48;
            }

            dailyTaskList.Generate<TaskItem>(numberOfSegments);
        }

        private static void writeBlankLine() {
            Console.WriteLine(String.Empty);
        }
    }
}

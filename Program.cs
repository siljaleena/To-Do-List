namespace To_Do_List
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        //declares a new list called toDoList
        private static List<string> toDoList = new List<string>();

        //represents the possible user actions
        private enum UserChoice
        
        {
            AddTask = 1,
            DeleteTask,
            Exit
        }

        //the main entry point of the program
        //this is the main method that has the menu for a to-do list
        public static void Main(string[] args)
            
        {
            //infinite loop to keep the program running until exited.
            while (true)
                
            {
                //checks if the to-do list is empty
                if (toDoList.Count > 0)
                {
                    Console.WriteLine("To-do List:");

                    //goes through the loop with all the tasks
                    for (int task = 0; task < toDoList.Count; task++)
                   {
                        //shows each task
                        Console.WriteLine("- " + toDoList[task]);
                        
                    }
                    //i added empty lines for better readability, serves no other purpose
                    Console.WriteLine("");
                }
                //this executes if there are no tasks in the to-do list
                else
                {
                    Console.WriteLine("You currently have no tasks in your to-do list.");
                    Console.WriteLine("");
                }
                //displays the menu with choices for the user
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Delete task");
                Console.WriteLine("3. Exit");


                //reads user input and parses it into an integer, then stores it in the variable 'choice'
                if (int.TryParse(Console.ReadLine(),out int choice))
                {
                    //this calls the 'ProcessUserChoice' method and handles the users selections
                    ProcessUserChoice(choice);
                }
                //this gets executed when something goes wrong
                else 
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please enter a number");
                }
            }





        //this method is for taking in user input and making the program act accordingly
        }
        public static void ProcessUserChoice(int choice)
        {
            //this line of code reads the value of 'choice' and executes the corresponding case based on the 'UserChoice' enum
            //For example, if 'choice' matches the value of (in this case) 1, the 'UserChoice.AddTask' gets executed
            switch ((UserChoice)choice)
           {
                //calls the 'AddTask' method
                //then exits the switch statement,if there was no 'break' here, the code would continue to all the other cases below.
                case UserChoice.AddTask:
                    AddTask();
                    break;


                //calls the 'DeleteTask' method
                case UserChoice.DeleteTask:
                    DeleteTask();
                    break;


                //exits the entire program with the status code of 0 which signifies that the program exited without errors
                case UserChoice.Exit:
                    Environment.Exit(0);
                    break;


                //in case 'choice' does not match any of the specified cases, this gets executed sending the user an error message
                //for example, if the user enters a number outside of the range of cases currently in the code
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please enter a valid option");
                    break;
            }
        }




        //Method for adding a task to the to-do list
        public static void AddTask()
        {
            //stores users input into the 'task' variable
            Console.Clear ();
            Console.Write("Enter task: ");
            string? task = Console.ReadLine();

            //checks if the entered task is not null or empty
            if (!string.IsNullOrEmpty(task))
            {
                //adds the valid task to the 'toDoList' collection
                toDoList.Add(task);
                Console.Clear () ;
                Console.WriteLine("Task added successfully!");
                Console.WriteLine("");
            }
        }


        //this method is for deleting a task
        private static void DeleteTask()
        {
            //checks if the to-do list has anything to delete first
            if (toDoList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the task you want to delete:");

                //this loops through each task to display them with corresponding numbers
                for (int task = 0; task < toDoList.Count; task++)
                {
                    //shows the tasks and their corresponding number so the user can choose which task to delete
                    //also edits task to be +1, so the task numbers are 1, 2, 3... instead of 0, 1, 2...
                    Console.WriteLine("(" + (task + 1) + ") " + toDoList[task]);
                }
                //checks user input and parses it into an integer.
                //then stores the integer in the variable 'TaskNum'
                //the 'out' indicates that 'TaskNum' is being declared and assigned.
                if (int.TryParse(Console.ReadLine(), out int TaskNum))
                {
                    //makes TaskNum match the task number so they are both 1, 2, 3... instead of 0, 1, 2...
                    TaskNum--;
                    //checks if the adjusted 'TaskNum' is valid with the tasks in 'toDoList'
                    if (TaskNum >= 0 && TaskNum < toDoList.Count)
                    {
                        toDoList.RemoveAt(TaskNum);
                        Console.Clear();
                        Console.WriteLine("Task deleted succesfully!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        //if an invalid number is used, this error message displays
                        Console.Clear();
                        Console.WriteLine("Invalid task number");
                    }
                } 
               
            }
            else
            {
                //if the list has nothing to delete, the program displays this message to the user
                Console.Clear();
                Console.WriteLine("No tasks to delete");
            }
        }
    }
}
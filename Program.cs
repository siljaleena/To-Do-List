namespace To_Do_List
{
    using System.Collections.Generic;
    internal class Program
    {
        enum UserChoice
        //the list of possible user actions:
        {
            AddTask = 1,
            DeleteTask,
            Exit
        }
        static void Main(string[] args)
        {
            List<string> toDoList = new List<string> ();
            //declares a new list called toDoList
            
            while (true)
            //while loop will run indefinitely until the user ends the program
            {
                if (toDoList.Count > 0)
                    //checks if the to-do list is empty
                {
                    Console.WriteLine("To-do List:");

                    for (int task = 0; task < toDoList.Count; task++)
                    {
                        Console.WriteLine("- " + toDoList[task]);
                    }
                    Console.WriteLine("");
                //if the to-do list has items(tasks) inside it, this will loop through each item in the array to display the name of the task
                }
                else
                {
                    Console.WriteLine("You currently have no tasks in your to-do list.");
                    Console.WriteLine("");
                //if the to-do list has no items(tasks) inside it, this message will display
                }
            
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Delete task");
                Console.WriteLine("3. Exit");
                int choice = int.Parse(Console.ReadLine());
                //asks for user input on different choices and acts according to what they pick with 'choice'

                if (choice == (int)UserChoice.AddTask)
                    //lets the user add a task
                {
                    Console.Write("Enter task: ");
                    string task = Console.ReadLine();
                    toDoList.Add(task);
                    Console.Clear();
                    Console.WriteLine("Task added successfully!");
                }

                else if (choice == (int)UserChoice.DeleteTask)
                    //lets the user delete a task
                {
                    if (toDoList.Count > 0)
                        //checks if the to-do list is empty first
                    {
                        Console.WriteLine("Enter the number of the task you want to delete:");

                        for (int task = 0; task < toDoList.Count; task++)
                        {
                            Console.WriteLine("(" + (task + 1) + ") " + toDoList[task]);
                        }
                        //shows the tasks and their corresponding number

                        int taskNum = int.Parse(Console.ReadLine());
                        //asks for user input to choose which task to remove
                        taskNum--;
                        if (taskNum >= 0 && taskNum < toDoList.Count)
                        {
                            toDoList.RemoveAt(taskNum);
                            Console.Clear();
                            Console.WriteLine("Task deleted succesfully!");
                            Console.WriteLine("");
                            //removes a task based on the number the user inputs   
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid task number");
                            Console.WriteLine();
                            //if the user inputs a number that does not have a corresponding task, this message will display
                        }
                    }
                }
                else if (choice == (int)UserChoice.Exit)
                {
                    break;
                    //If the user chooses to exit, this will break the loop and the application will close.
                }
            }
        }
    }
}

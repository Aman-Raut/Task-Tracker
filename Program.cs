using System;
using System.Collections.Generic;

class Task
{
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}

class TaskTracker
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nTask Tracker Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark as Completed");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;

                case "2":
                    MarkAsCompleted();
                    break;

                case "3":
                    ViewTasks();
                    break;

                case "4":
                    DeleteTask();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task name: ");
        string name = Console.ReadLine();

        Console.Write("Enter due date (yyyy-mm-dd): ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());

        Task newTask = new Task { Name = name, DueDate = dueDate };
        tasks.Add(newTask);

        Console.WriteLine("Task added successfully!");
    }

    static void MarkAsCompleted()
    {
        ViewTasks();

        Console.Write("Enter the index of the task to mark as completed: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsCompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid index. No task found at the specified index.");
        }
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nList of Tasks:");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Name} (Due: {tasks[i].DueDate.ToString("yyyy-MM-dd")}, Completed: {tasks[i].IsCompleted})");
        }

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
    }

    static void DeleteTask()
    {
        ViewTasks();

        Console.Write("Enter the index of the task to delete: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid index. No task found at the specified index.");
        }
    }
}

List<string> TaskList = new List<string>();

        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if ((Menu)menuSelected == Menu.Add)
            {
                ShowMenuAddTasks();
            }
            else if ((Menu)menuSelected == Menu.Remove)
            {
                ShowMenuRemoveTasks();
            }
            else if ((Menu)menuSelected == Menu.List)
            {
                ShowMenuTasksList();
            }
        } while ((Menu)menuSelected != Menu.Exit);
    /// <summary>
    /// Show the options to manage tasks, 1 is for new task, 2 is for remove task, 3 is for  pending task, 4 is exit.
    /// </summary>
    /// <returns>Returns option selected by user</returns>
    int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        string userInput = Console.ReadLine();
        return TryCatchForStringToNumber(userInput);
    }
    void ShowMenuAddTasks()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string taskToAdd = Console.ReadLine();
            if (taskToAdd.Length <= 0)
            {
                Console.WriteLine("No se pueden agregar tareas vacias.");
            }
            else
            {
                TaskList.Add(taskToAdd);
                Console.WriteLine("Tarea registrada");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error inesperado al eliminar la tarea.");
        }
    }
    void ShowMenuRemoveTasks()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            ShowTasksList();
            string taskNumberToDelete = Console.ReadLine();
            TryCatchForStringToNumber(taskNumberToDelete);
            

                //Remove one position cuz the array starts in 0
                int indexToRemove = int.Parse(taskNumberToDelete) -1;

                if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("El número de tarea está fuera del rango de tareas creadas.");
                }
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea '{task}' eliminada");
                    }
                }
        }
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error inesperado al eliminar la tarea.");
        }
    }

    void ShowMenuTasksList()
    {
        if (TaskList?.Count > 0)
        {
            ShowTasksList();  
        }
        else
        {
            Console.WriteLine("No hay tareas por realizar");
        }
    }

    void ShowTasksList()
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 1;
        TaskList.ForEach(task=> Console.WriteLine($"{indexTask++}.{task}"));
        Console.WriteLine("----------------------------------------");
    }

    int TryCatchForStringToNumber(string textoAComprobar)
    {
        var i = 0;
        if (!int.TryParse(textoAComprobar, out i))
        {
            Console.WriteLine("Ingrese una opción válida");
            return ((int)Menu.Continue);
        }
        else
        {
            return Convert.ToInt32(textoAComprobar);
        }
    }
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4,
        Continue = 5
    }

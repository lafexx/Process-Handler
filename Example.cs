
public class Example : Monobehaviour
{
    // creating our process handler
    public Process_Handler process_handler = new Process_Handler();

    private void Start()
    {
        // trying to add a task to the active process
        process_handler.TryToCreateTask("Task 1", this, "FUNCTION_1");
        // trying to add another task to the active process
        process_handler.TryToCreateTask("Task 2", this, "FUNCTION_2");
        // when the process handler completes all the tasks in the process run this function
        process_handler.WhenTasksComplete(this, "WhenTasksComplete"); // PARAM 1 is should be the class that holds the function
    }

    // when creating a function for a task it needs to be public, static and return a boolean which tells the task if the function was succesfull
    public static bool FUNCTION_1()
    {
        Debug.Log("FUNCTION_1");
        return true;
    }

    public static bool FUNCTION_2()
    {
        Debug.Log("FUNCTION_2");
        return true;
    }

    // this is the function that we set to run when the process handler completes all the tasks
    public static void WhenTasksComplete()
    {
        Debug.Log("All the tasks have been completed");
        // trying to add a tak to the active process
        Task created_task = process_handler.TryToCreateTask("Task 1 ", this, "FUNCTION_1");
        // adding the new task to the retry list (this makes it so the task repeats)
        process_handler.AddTaskToRetryList(created_task);
    }
}

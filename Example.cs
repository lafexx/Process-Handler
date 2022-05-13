
public class Example : Monobehaviour
{
    // creating our process handler
    public Process_Handler process_handler = new Process_Handler();

    private void Start()
    {
        process_handler.TryToCreateTask("Task 1", "FUNCTION_1");
        process_handler.TryToCreateTask("Task 2", "FUNCTION_2");
        process_handler.WhenTasksComplete(this, "WhenTasksComplete");
    }

    public static void WhenTasksComplete()
    {
        Debug.Log("All the tasks have been completed");
    }
}
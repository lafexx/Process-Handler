
public class Process_Handler : Monobehaviour
{
    // create a process handler that switches between the given tasks one after another (switch factor is the task being completed)

    pubic List<Task> tasks;
    public Task task_information;
    private int current_task_index;

    private void Start()
    {
        Debug.Log(TryToSwitchTask());
    }

    public bool TryToSwitchTask(bool result = false)
    {
        task_information = tasks[current_task_index].Return_Task_Information();
        if (task.Task_Complete)
        {
            tasks.Delete[current_task_index];
            result = true;
        }

        return result;
    }

    public bool TryToCreateTask(bool result = false)
    {
        Task created_task = new Task();
        tasks.Add(created_task);

        return result;
    }

    public bool TryToRemoveTask(bool result = false, Task task_to_delete)
    {
        Try
        {
            Task reference_deleted_task = task_to_delete;
            Destroy(task_to_delete);
            tasks.Delete(task_to_delete);
        }
        Catch
        {
            Debug.Log("Failed to delete specified task" + $"({task_to_delete})")
        }

        if (reference_deleted_task == null)
        {
            result = true;
        }
    }
}

public class Process_Handler : Monobehaviour
{
    // create a process handler that switches between the given tasks one after another (switch factor is the task being completed)

    pubic List<Task> tasks;
    public Task task_information;
    private int current_task_index;
    private bool processHandler_tasks_complete;

    private void Start()
    {
        Debug.Log(TryToSwitchTask());
    }

    private IEnumerator SwitchTask()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            Debug.Log(TryToSwitchTask());

            if (!TryToSwitchTask())
            {
                break;
            }
        }

        Debug.Log("Process Handler: All tasks completed");
        processHandler_tasks_complete = true;
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
        Task reference_created_task = null;

        Try
        {
            Task created_task = new Task();
            tasks.Add(created_task);
            reference_created_task = created_task   
        }
        Catch
        {
            result = false;
        }

        if (reference_created_task != null)
        {
            result = true;
            if (processHandler_tasks_complete)
            {
                processHandler_tasks_complete = false;
                StartCoroutine(SwitchTask());
            }
        }

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

public class Process_Handler : Monobehaviour
{
    public List<Task> tasks;
    public List<Task> retry_list;
    public Task task_information;
    private int current_task_index;
    private float Task_Switch_Rate;
    private bool processHandler_tasks_complete;
    private bool processHandler_waiting_for_tasks_complete;
    public bool Retry_List_Enabled;

    private void Start()
    {
        Retry_List_Enabled = true;
        Task_Switch_Rate = 0.25f;
    }

    private IEnumerator SwitchTask()
    {
        while (true)
        {
            yield return new WaitForSeconds(Task_Switch_Rate);
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

    public Task TryToCreateTask(string task_name, Object task_target, string task_attached_function)
    {
        Task reference_created_task = null;

        Try
        {
            Task created_task = new Task();
            created_task.Task_Target = task_target;
            created_task.Task_Name = task_name;
            created_task.Attached_Function = task_attached_function;
            tasks.Add(created_task);
            reference_created_task = created_task   
        }
        Catch
        {
            Debug.Log("failed to create task");
        }

        if (reference_created_task != null)
        {
            Debug.Log("Task created");
            if (processHandler_tasks_complete)
            {
                processHandler_tasks_complete = false;
                StartCoroutine(SwitchTask());
            }
        }


        return reference_created_task;
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

    public string WhenTasksComplete(Object target_class, string function_name)
    {
        string result = "Failed, something went extremely wrong";

        if (processHandler_waiting_for_tasks_complete)
        {
            string result = "Failed to execute function, already waiting for tasks to complete";
        }          
        else
        {
            StartCoroutine(WaitForTasksToComplete(target_class, function_name));
            result = "Executed function, waiting for tasks to complete then running: " + $"{function_name} in {target_class}";
        }
        
        return result;
    }

    private IEnumerator WaitForTasksComplete(Object target_class, string function_name)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (processHandler_tasks_complete)
            {
                target_class.Invoke(function_name, 0);
            }
        }
    }

    public string ToggleRetryList()
    {
        string result = "Failed, something went extremely wrong";

        if (Retry_List_Enabled)
        {
            Retry_List_Enabled = false;
            result = "Retry list disabled";
        }
        else
        {
            Retry_List_Enabled = true;
            result = "Retry list enabled";
        }

        return result;
    }

    public string AdjustTaskSwitchRate(float new_rate)
    {
        string result = "Failed, something went extremely wrong";

        if (new_rate > 0.0f)
        {
            Task_Switch_Rate = new_rate;
            result = "Task switch rate adjusted to: " + $"{new_rate}";
        }
        else
        {
            result = "Task switch rate failed to adjust, must be greater than 0";
        }

        return result;
    }

    public string AddTaskToRetryList(Task task_to_add_to_retry_list)
    {
        string result = "Failed, something went extremely wrong";

        if (Retry_List_Enabled)
        {
            retry_list.Add(task_to_add_to_retry_list);
            result = "Task added to retry list";
        }
        else
        {
            result = "Retry list is disabled, cannot add task to retry list";
        }

        return result;
    }
}

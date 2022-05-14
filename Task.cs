
public class Task : Monobehaviour
{
    public Object Task_Target;
    public string Attached_Function;
    public bool Task_Complete;
    public string Task_Name;
    public bool Task_Added_To_Retry_List;

    public void Start()
    {
        if (Task_Target.Invoke(Attached_Function, 0.0f))
        {
            Task_Complete = true;   
        }
        else
        {
            Task_Complete = true;
            Process_Handler.TryToCreateTask(Task_Name, Task_Target, Attached_Function);
            Debug.Log("Task failed to complete adding to the retry list");
        }
    }

    public static Task Return_Task_Information()
    {
        return this;
    }
}

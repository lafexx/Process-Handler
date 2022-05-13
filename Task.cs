
public class Task : Monobehaviour
{
    public Object Task_Target;
    public string Attached_Function;
    public bool Task_Complete;
    public string Task_Name;

    public void Start()
    {
        if (Task_Target.Invoke(Attached_Function, 0.0f))
        {
            Task_Complete = true;   
        }
        else
        {
            Task_Complete = true; // this is a temporary solution
            Debug.Log("Task failed to complete adding to the retry list");
            // TODO: Add to retry list
        }
    }

    public static Task Return_Task_Information()
    {
        return this;
    }
}

using UnityEngine;

public class WindowService:IService
{
    public void Open(GameObject window)
    {
        if(window != null)
        {
            window.SetActive(true);
        }
    }

    public void Close(GameObject window)
    {
        if(window != null) 
        {
            window.SetActive(false);
        }
    }
}

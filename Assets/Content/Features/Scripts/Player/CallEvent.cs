using UnityEngine;

public class CallEvent : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Walet.OnChange?.Invoke();
        }
    }
}

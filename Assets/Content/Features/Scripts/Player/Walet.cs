using System;
using UnityEngine;

public class Walet : MonoBehaviour
{
    public static Action OnChange;
    
    private void Start()
    {
        OnChange += Function;
    }
    
    void Function()
    {
        Debug.Log("Change");
    }

    void OnDestroy()
    {
        OnChange -= Function;
    }
}

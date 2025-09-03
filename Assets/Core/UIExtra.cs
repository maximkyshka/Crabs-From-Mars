using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIExtra : MonoBehaviour
{
    public GameObject[] Obj;
    public Key[] onOff;
    
    public void OnOff(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    private void Update()
    {
        for (int i = 0; i < Obj.Length; i++)
        {
            if (Input.GetButton(onOff[i].ToString()))
            {
                OnOff(Obj[i]);
            }
        }
    }
}

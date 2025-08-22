using UnityEngine;

public class UIExtra : MonoBehaviour
{
    public void OnOff(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}

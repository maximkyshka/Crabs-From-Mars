using UnityEngine;

public class ItemObj : MonoBehaviour, IItemObj
{
    [SerializeField] private int count = 1;
    [SerializeField] private Item itemType;
    public int Count()
    {
        return count;
    }
    
    public Item ItemType()
    {
        return itemType;
    }
}
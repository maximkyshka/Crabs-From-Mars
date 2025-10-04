using UnityEngine;

public class ItemObj : MonoBehaviour, IItemObj
{
    public int count;
    public Items.Item itemType;
    public int Count()
    {
        return count;
    }
    public Items.Item ItemType()
    {
        return itemType;
    }
}

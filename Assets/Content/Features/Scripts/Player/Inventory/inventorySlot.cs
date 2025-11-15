[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int count;

    public void Clear()
    {
        item = null;
        count = 0;
    }
}
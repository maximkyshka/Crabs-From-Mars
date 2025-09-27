using UnityEngine;
using static Items;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private ItemViev[] itemVievs;
    [SerializeField] private Item[] items;
    [SerializeField] private int[] itemsNum;
    
    [SerializeField] private Item Null;
    
    [SerializeField] private int itemSelected;

    public bool UseItem(int index, int num)
    {
        if(items[index] != Null && itemsNum[index] >= num)
        {
            itemsNum[index] -= num;
            ReloadHotBar();
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool AddItem(Item item, int num)
    {
        int slot = -1;
        
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item && slot == -1)
            {
                slot = i;
            }
        }
        
        if (slot == -1)
        {
            if (items[itemSelected] != Null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == Null && slot == -1)
                    {
                        itemsNum[slot] = 0;
                        slot = i;
                    }
                }
            }
            else
            {
                slot = itemSelected;
            }
        }
        
        if (slot != -1)
        {
            return false;
        }
        else
        {
            items[slot] = item;
            itemsNum[slot] += num;
            ReloadHotBar();
            return true;
        }
    }

    private void ReloadHotBar()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (itemsNum[i] <= 0)
            {
                itemVievs[i].SetItem(Null, 1, i);
                items[i] = Null;
            }
            else
            {
                itemVievs[i].SetItem(items[i], itemsNum[i], i);
            }
        }
    }
}

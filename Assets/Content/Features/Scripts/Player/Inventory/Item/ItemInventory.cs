using UnityEngine;
using static Items;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private ItemArray[] itemsInventory;
    [SerializeField] private ItemArray itemsHotBar;
    
    
    [SerializeField] private Item item;

    private void Update()
    {
        for (int i = 0; i < itemsInventory.Length; i++)
        {
            for (int j = 0; j < itemsInventory[i].items.Length; j++)
            {
                itemsInventory[i].itemVievs[j].SetItem(itemsInventory[i].items[j]);
            }
        }

        for (int i = 0; i < itemsHotBar.items.Length; i++)
        {
            itemsHotBar.itemVievs[i].SetItem(itemsHotBar.items[i]);
        }
    }
}

class ItemArray
{
    public ItemViev[] itemVievs;
    public Item[] items;
}

// Файл: ItemInventory.cs

using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private ItemView[] itemViews;
    
    [Header("Data")]
    [SerializeField] private InventorySlot[] slots;
    
    [SerializeField] private int itemSelected;
    
    private void Start()
    {
        if (slots.Length != itemViews.Length)
        {
            return;
        }
        ReloadInventoryUI();
    }

    public bool UseItem(int index, int amount)
    {
        if (index < 0 || index >= slots.Length) return false;

        if (slots[index].item != null && slots[index].count >= amount)
        {
            if (slots[index].item.IsStackable)
            {
                slots[index].count -= amount;
            }
            else
            {
                slots[index].count = 0;
            }

            if (slots[index].count <= 0)
            {
                slots[index].Clear();
            }

            ReloadInventoryUI();
            return true;
        }
        return false;
    }
    
    public bool AddItem(Item itemToAdd, int amount)
    {
        if (itemToAdd.IsStackable)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == itemToAdd)
                {
                    slot.count += amount;
                    ReloadInventoryUI();
                    return true;
                }
            }
        }

        if (slots[itemSelected].item == null)
        {
            slots[itemSelected].item = itemToAdd;
            slots[itemSelected].count = itemToAdd.IsStackable ? amount : 1;
            ReloadInventoryUI();
            return true;
        }
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].item = itemToAdd;
                slots[i].count = itemToAdd.IsStackable ? amount : 1;
                ReloadInventoryUI();
                return true;
            }
        }

        Debug.Log("Інвентар повний, неможливо додати " + itemToAdd.name);
        return false;
    }

    private void ReloadInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null && slots[i].count > 0)
            {
                itemViews[i].SetItem(slots[i].item, slots[i].count, i);
            }
            else
            {
                if(slots[i].item != null) slots[i].Clear();
                itemViews[i].Clear();
            }
        }
    }
}
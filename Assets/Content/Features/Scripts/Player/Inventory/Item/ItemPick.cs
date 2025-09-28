using UnityEngine;

public class ItemPick : MonoBehaviour
{
    private ItemInventory itemInventory;
    
    float pickUpRange = 10f;

    private void Awake()
    {
        itemInventory = GetComponent<ItemInventory>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickUpRange);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent(out IItemObj item))
            {
                if (itemInventory.AddItem(item.ItemType(), item.Count()))
                {
                    Destroy(hitCollider.gameObject);
                }
            }
        }
    }
}

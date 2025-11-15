using UnityEngine;

[RequireComponent(typeof(ItemInventory))]
public class ItemPick : MonoBehaviour
{
    private ItemInventory itemInventory;
    
    [SerializeField] private float pickUpRange = 10f;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        itemInventory = GetComponent<ItemInventory>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickUpRange, layerMask);
        
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
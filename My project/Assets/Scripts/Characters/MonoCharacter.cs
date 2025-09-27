using UnityEngine;

public abstract class MonoCharacter : MonoBehaviour
{
    [SerializeField] protected Transform handTransform;
    
    protected virtual void Start()
    {
        DisplayHand();
    }

    protected virtual void DisplayHand()
    {
        Item item = handTransform.GetComponentInChildren<Item>();
        Debug.Log("Displaying hand for " + item.itemName);
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite { get => sprite; }
    
        [SerializeField] private ItemType itemType;
        public ItemType ItemType { get => itemType; }
    }
    
    public enum ItemType
    {
        Wood,
        Stone,
        Iron,
        Meat,
        none
    }
}

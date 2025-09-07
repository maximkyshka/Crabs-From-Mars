using UnityEngine;

public class Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite { get => sprite; }
    
        [SerializeField] private string name;
        public string Name { get => name; }
        
        [SerializeField] private string description;
        public string Description { get => description; }
    
        [SerializeField] private ItemType itemType;
        public ItemType ItemType { get => itemType; }
        
        [SerializeField] private int stackSize;
        public int StackSize { get => stackSize; }
    }
    
    public enum ItemType
    {
        Wood,
        Stone,
        Iron,
        WoodenSword,
        StoneSword,
        IronSword,
        WoodenAxe,
        StoneAxe,
        IronAxe,
        WoodenPickaxe,
        Bow,
        StonePickaxe,
        IronPickaxe,
        WoodenShovel,
        StoneShovel,
        IronShovel,
        WoodenHoe,
        StoneHoe,
        IronHoe,
        WoodenHelmet,
        WoodenChestplate,
        StoneChestplate,
        IronChestplate,
        WoodenLeggings,
        StoneLeggings,
        IronLeggings,
        WoodenBoots,
        StoneBoots,
        IronBoots,
        none
    }
    
    [CreateAssetMenu(fileName = "New Item Bilds", menuName = "Inventory/ItemBilds")]
    public class ItemBilds : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite { get => sprite; }
        
        public string Name { get => itemBildsType + " " + itemBildsMaterial; }
        
        [SerializeField] private string description;
        public string Description { get => description; }
    
        [SerializeField] private ItemBildsType itemBildsType;
        public ItemBildsType ItemBildsType { get => itemBildsType; }
    
        [SerializeField] private ItemBildsMaterial itemBildsMaterial;
        public ItemBildsMaterial ItemBildsMaterial { get => itemBildsMaterial; }

        [SerializeField] private Crafting[] crafting;
        public Crafting[] Crafting { get => crafting; }
    }
    
    [CreateAssetMenu(fileName = "New Crafting", menuName = "Inventory/Crafting")]
    public class Crafting : ScriptableObject
    {
        public ItemType[] Items;
        public ItemType[] result;
    }

    public enum ItemBildsType
    {
        Wall,
        Floor
    }

    public enum ItemBildsMaterial
    {
        Wood,
        Stone,
        Iron
    }
}

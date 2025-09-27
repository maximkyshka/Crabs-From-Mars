using UnityEngine;
using static Items;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using TMPro;

public class ItemViev : MonoBehaviour
{
    [SerializeField] private int index = -1;
    [SerializeField] private Item item;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text numText;
    [SerializeField] private Button button;

    public int num;
    
    private void Start()
    {
        Setup();
    }

    private void Use()
    {
        if (num > 0)
        {
            num--;
            Reload();
        }
    }
    
    public void SetItem(Item Item, int Value, int Index){ item = Item; Setup(); num = Value; index = Index; }

    public void Setup() 
    { 
        image.sprite = item.Sprite != null ? item.Sprite : null; 
        button.onClick.AddListener(Use);
        Reload(); 
    }

    private void Reload() { numText.text = num == 1 ? "" : num.ToString(); }
}

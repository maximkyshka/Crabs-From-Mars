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

    public int num = -1;

    public void SetItem(Item Item, int Value, int Index)
    {
        item = Item; 
        num = Value; 
        index = Index; 
        Setup();
    }

    public void Setup()
    {
        if(index == -1) return;
        if (item.Sprite == null) image.enabled = false; 
        else image.sprite = item.Sprite != null ? item.Sprite : null;
        
        Reload(); 
    }

    private void Reload()
    {
        numText.text = num == 1 ? "" : num == -1 ? "" : num.ToString();
    }
}

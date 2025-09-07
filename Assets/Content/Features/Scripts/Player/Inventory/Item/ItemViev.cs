using UnityEngine;
using static Items;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ItemViev : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Image image;
    [SerializeField] private Text numText;
    [SerializeField] private GameObject panelDescription;
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Button button;
    
    private bool isDragging;

    public int num
    {
        get => num;
        set
        {
            num = value;
            Reload();
        }
    }
    
    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if (!isDragging)
        {
            
        }
    }

    private void Use()
    {
        if (num > 0)
        {
            num--;
            Reload();
        }
    }

    private void Setup() 
    { 
        image.sprite = item.Sprite; 
        nameText.text = item.Name; 
        descriptionText.text = item.Description;
        button.onClick.AddListener(Use);
        Reload(); 
    }

    private void Reload() { numText.text = num == 0 ? "" : num.ToString(); }
}

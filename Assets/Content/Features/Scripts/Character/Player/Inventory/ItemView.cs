using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField] private int index = -1;
    [SerializeField] private Item item;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text numText;
    [SerializeField] private Button button;

    private int num = -1;

    public void SetItem(Item newItem, int value, int newIndex)
    {
        item = newItem; 
        num = value; 
        index = newIndex; 
        UpdateView();
    }

    public void Clear()
    {
        item = null;
        num = 0;
        UpdateView();
    }
    
    private void UpdateView()
    {
        if (item != null)
        {
            if (image != null)
            {
                image.sprite = item.Sprite;
                image.enabled = true;
            }
            
            if (numText != null)
            {
                if (item.IsStackable && num > 1)
                {
                    numText.text = num.ToString();
                    numText.enabled = true;
                }
                else
                {
                    numText.enabled = false;
                }
            }
        }
        else
        {
            if (image != null)
            {
                image.sprite = null;
                image.enabled = false;
            }

            if (numText != null)
            {
                numText.text = "";
                numText.enabled = false;
            }
        }
    }
}
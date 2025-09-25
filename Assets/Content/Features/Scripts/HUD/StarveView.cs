using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Starveview : MonoBehaviour
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private TMP_Text hungerText;

    private void OnEnable()
    {
        Starve.OnStarveChanged += UpdateView;
    }

    private void OnDisable()
    {
        Starve.OnStarveChanged -= UpdateView;
    }

    private void UpdateView(int currentHunger)
    {
        if (hungerBar != null)
            hungerBar.value = currentHunger;

        if (hungerText != null)
            hungerText.text = currentHunger.ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarveView : MonoBehaviour, IStarveView
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private TMP_Text hungerText;
    [SerializeField] private Starve currentStarve;

    public Slider HungerBar
    {
        get => hungerBar;
        set => hungerBar = value;
    }

    public TMP_Text HungerText
    {
        get => hungerText;
        set => hungerText = value;
    }

    public Starve CurrentStarve
    {
        get => currentStarve;
        set => currentStarve = value;
    }

    private void OnEnable()
    {
        if (currentStarve != null)
            currentStarve.OnStarveChanged += UpdateView;
    }

    private void OnDisable()
    {
        if (currentStarve != null)
            currentStarve.OnStarveChanged -= UpdateView;
    }

    public void UpdateView(int hungerValue)
    {
        if (hungerBar == null || hungerText == null) return;

        hungerBar.value = hungerValue;
        hungerText.text = $"Hunger: {hungerValue}";
    }
}

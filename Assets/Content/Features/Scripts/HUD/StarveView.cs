using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StarveView : MonoBehaviour, IStarveView
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private TMP_Text hungerText;
    [SerializeField] private Starve currentStarve;

    private void OnEnable()
    {
        Starve.OnStarveChanged += UpdateView;
    }

    private void OnDisable()
    {
        Starve.OnStarveChanged -= UpdateView;
    }

    public void UpdateView(int hungerValue)
    {
        if (currentStarve == null || hungerBar == null || hungerText == null) return;

        hungerBar.value = hungerValue;
        hungerText.text = hungerValue.ToString();
    }
}

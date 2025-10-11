using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IHealthView
{
    Health Health { get; set; }
    Slider HealthSlider { get; set; }
    TMP_Text HealthText { get; set; }
    GameObject DeathScreen { get; set; }

    void UpdateUI(int current, int max);
    void ShowDeathScreen();
}

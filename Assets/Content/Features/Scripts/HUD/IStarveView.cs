using TMPro;
using UnityEngine.UI;

public interface IStarveView
{
    Slider HungerBar { get; set; }
    TMP_Text HungerText { get; set; }
    Starve CurrentStarve { get; set; }

    void UpdateView(int hungerValue);
}

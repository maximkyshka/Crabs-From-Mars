using UnityEngine;

public interface IHealthView
{
    public void UpdateUI(int current, int max);
    public void ShowDeathScreen();
}

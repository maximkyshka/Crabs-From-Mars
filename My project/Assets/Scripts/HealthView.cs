using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    
    private IDamageable _demageable;

    private void Awake()
    {
        _demageable = GetComponent<IDamageable>();
        _demageable.OnHealthChanged += HealthChenget;
    }

    private void HealthChenget(int health) { healthSlider.value = _demageable.GetHealthPercent(); }
}

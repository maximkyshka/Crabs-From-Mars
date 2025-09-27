using System;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage);
    public void Healing(int heal);
    public int GetHealth();
    public float GetHealthPercent();
    public event Action<int> OnHealthChanged;
}

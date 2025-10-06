using System;
using UnityEngine;

public interface IHealth
{
    public int MaxHealth { get;}
    public int CurrentHealth { get;}

    public Action<int, int> OnHealthChanged { get; set; }
    public Action OnDeath { get; set; }
    public void TakeDamage(int damage);
   public void Heal(int amount);
}

using UnityEngine;
using System;
public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => health;

    public Action<int, int> OnHealthChanged;
    public Action OnDeath;

    void Awake()
    {
        health = maxHealth;
    }

    void Start()
    {
        OnHealthChanged?.Invoke(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChanged?.Invoke(health, maxHealth);

        if (health <= 0)
            OnDeath?.Invoke();
    }

    public void Heal(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChanged?.Invoke(health, maxHealth);
    }
}
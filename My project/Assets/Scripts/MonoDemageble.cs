using System;
using UnityEngine;

public class MonoDemageble : MonoBehaviour, IDamageable
{
    [SerializeField] private int currentHealth = 110;
    [SerializeField] private int maxHealth = 100;
    
    public event Action OnDeath;
    public event Action<int> OnHealthChanged;

    private void Start()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    private void OnValidate() =>
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
        
        OnHealthChanged?.Invoke(currentHealth);
    }
    
    public int GetHealth() => 
        currentHealth;
    
    public void Healing(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        OnHealthChanged?.Invoke(currentHealth);
    }
    
    public float GetHealthPercent() => currentHealth / (float)currentHealth;
}

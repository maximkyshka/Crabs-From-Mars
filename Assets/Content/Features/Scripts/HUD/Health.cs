using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private GameObject DeathScreen;

    void Start()
    {
        health = maxHealth;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthSlider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
            DeathScreen.SetActive(true);
        }
    }
}
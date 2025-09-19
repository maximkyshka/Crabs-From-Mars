using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject DeathScreen;

    void Start()
    {
        health = maxHealth;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = health;
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthSlider.value = health;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
            DeathScreen.SetActive(true);
        }
    }
}
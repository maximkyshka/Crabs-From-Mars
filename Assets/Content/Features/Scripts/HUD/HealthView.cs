using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject deathScreen;

    void Awake()
    {
        if (health == null)
            health = GetComponent<Health>();
    }

    void OnEnable()
    {
        if (health != null)
        {
            health.OnHealthChanged += UpdateUI;
            health.OnDeath += ShowDeathScreen;
        }
    }

    void OnDisable()
    {
        if (health != null)
        {
            health.OnHealthChanged -= UpdateUI;
            health.OnDeath -= ShowDeathScreen;
        }
    }

    private void UpdateUI(int current, int max)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = max;
            healthSlider.value = current;
        }

        if (healthText != null)
        {
            healthText.text = current.ToString();
        }
    }

    private void ShowDeathScreen()
    {
        if (deathScreen != null)
            deathScreen.SetActive(true);

        if (deathScreen == null)
            Destroy(health.gameObject);
    }
}

using UnityEngine;

public class SurvivalManager : MonoBehaviour
{
    private IHealth health;
    private IStarve starve;

    [SerializeField] private int starveDamage = 5;

    private void Awake()
    {
        health = GetComponent<IHealth>();
        starve = GetComponent<IStarve>();

        if (starve != null)
            starve.OnStarveChanged += OnStarveChanged;

        if (health != null)
        {
            health.OnHealthChanged += OnHealthChanged;
            health.OnDeath += OnDeath;
        }
    }

    private void OnDestroy()
    {
        if (starve != null)
            starve.OnStarveChanged -= OnStarveChanged;

        if (health != null)
        {
            health.OnHealthChanged -= OnHealthChanged;
            health.OnDeath -= OnDeath;
        }
    }

    private void OnStarveChanged(int hunger)
    {
        if (hunger <= 0 && health != null)
        {
            health.TakeDamage(starveDamage);
        }
    }

    private void OnHealthChanged(int current, int max)
    {
        Debug.Log($"[Survival] Health: {current}/{max}");
    }

    private void OnDeath()
    {
        Debug.Log("[Survival] Player died!");
    }
}

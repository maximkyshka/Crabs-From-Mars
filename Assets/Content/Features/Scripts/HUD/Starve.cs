using UnityEngine;
using System;
using System.Collections;
public class Starve : MonoBehaviour, IStarve
{
    public event Action<int> OnStarveChanged;

    public int hunger = 100;
    [SerializeField] private int decreaseRate = 1;
    [SerializeField] private float updateDelay = 1f;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        StartCoroutine(UpdateStarve());
        OnStarveChanged?.Invoke(hunger);
    }

    public System.Collections.IEnumerator UpdateStarve()
    {
        while (true)
        {
            if (hunger <= 0)
            {
                yield return new WaitForSeconds(1f);
                health.TakeDamage(10);
            }
            yield return new WaitForSeconds(updateDelay);

            int rate = CalculateDynamicRate();
            hunger = Mathf.Max(0, hunger - rate);
            OnStarveChanged?.Invoke(hunger);
        }
    }

    public int CalculateDynamicRate()
    {
        if (health == null) return decreaseRate;

        float hpPercent = (float)health.CurrentHealth / health.MaxHealth;
        if (hpPercent < 0.25f) return decreaseRate * 3;
        if (hpPercent < 0.5f) return decreaseRate * 2;

        return decreaseRate;
    }
}

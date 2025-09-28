using UnityEngine;
using System;

public class Starve : MonoBehaviour
{
    public static event Action<int> OnStarveChanged;

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

    private System.Collections.IEnumerator UpdateStarve()
    {
        while (true)
        {
            if (hunger <= 0)
            {
                yield return new WaitForSeconds(1f);
                health.TakeDamage(20);
            }
            yield return new WaitForSeconds(updateDelay);

            int rate = CalculateDynamicRate();
            hunger = Mathf.Max(0, hunger - rate);

            OnStarveChanged?.Invoke(hunger);
        }
    }

    private int CalculateDynamicRate()
    {
        if (health == null) return decreaseRate;

        float hpPercent = (float)health.CurrentHealth / health.MaxHealth;
        if (hpPercent < 0.25f) return decreaseRate * 3;
        if (hpPercent < 0.5f) return decreaseRate * 2;

        return decreaseRate;
    }
    public void Update()
    {
        
    }
}

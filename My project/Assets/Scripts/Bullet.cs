using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float dem = 10f;
    private void OnCollisionEnter(Collision other)
    {
        if (TryGetComponent(out IDamageable health))
        {
            health.TakeDamage((int)dem);
        }
    }
}

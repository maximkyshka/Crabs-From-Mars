using UnityEngine;

public class HealsePlayerControler : MonoBehaviour, IHealse
{
    public int Healse { get; set; }
    public int HealseMax { get; set; }
    public int Regen { get; set; }
    public void Healsed(int healse)
    {
        Healse += healse;
        Healse = Mathf.Clamp(Healse, 0, HealseMax);
    }

    public void Hit(int Damage)
    {
        Healse -= Damage;
        if (Healse <= 0) Die();
    }

    public void Die()
    {
        Debug.Log("Die");
    }

    public void Regened(int regen)
    {
        throw new System.NotImplementedException();
    }
}
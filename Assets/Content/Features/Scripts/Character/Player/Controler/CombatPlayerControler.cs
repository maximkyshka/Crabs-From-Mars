using UnityEngine;

public class CombatPlayerControler : MonoBehaviour, ICombat
{
    public int HitDamage { get; set; }
    public float HitDamageSpeed { get; set; }
    public float HitDamageRadius { get; set; }
    public LayerMask CanHit { get; set; }
}
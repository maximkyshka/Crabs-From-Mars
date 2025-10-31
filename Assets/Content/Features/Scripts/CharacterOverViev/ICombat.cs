using UnityEngine;

public interface ICombat
{
    public int HitDamage { get; set; }
    public float HitDamageSpeed { get; set; }
    public float HitDamageRadius { get; set; }
    public LayerMask CanHit { get; set; }
}
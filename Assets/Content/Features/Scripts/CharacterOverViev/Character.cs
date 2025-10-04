using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [Header("Health")]
    [field: SerializeField] public int HealthCurrent { get; set; }
    [field: SerializeField] public  int HealthMax { get; set; }
    [field: SerializeField] public  float RegenerationSpeed { get; set; }
    
    [Header("Food")]
    [field: SerializeField] public int FoodCurrent { get; set; }

    [Header("Damage")]
    [field: SerializeField] public int HitDamage { get; set; }
    [field: SerializeField] public float HitDamageSpeed { get; set; }
    [field: SerializeField] public float HitDamageRadius { get; set; }

    [Header("Speed")]
    [field: SerializeField] public float SpeedTurn { get; set; }
    [field: SerializeField] public float SpeedWalk { get; set; }
    [field: SerializeField] public float SpeedRun { get; set; }
    [field: SerializeField] public AnimationCurve SpeedCurve { get; set; }

    public void Start()
    {
        InvokeRepeating(nameof(Regeneration), 0f, RegenerationSpeed);
    }

    public void Regeneration()
    {
        if (HealthCurrent < HealthMax && FoodCurrent > 0)
        {
            FoodCurrent--;
            HealthCurrent++;
        }
    }

    public void Damage(int damage)
    {
        HealthCurrent -= damage;
        if (HealthCurrent <= 0) Die();
    }

    public bool Heal(int heal)
    {
        if (HealthCurrent < HealthMax)
        {
            HealthCurrent += heal;
            HealthCurrent = Mathf.Clamp(HealthCurrent, 0, HealthMax);
            return true;
        }
        
        return false;
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public bool Eat(int food)
    {
        if(FoodCurrent < 100)
        {
            FoodCurrent += food;
            FoodCurrent = Mathf.Clamp(FoodCurrent, 0, 100);
            return true;
        }
        
        return false;
    }

    public void Instantiate(CharacterSetings character)
    {
        HealthMax = character.MaxHealth;
        HealthCurrent = character.MaxHealth;
        RegenerationSpeed = character.RegenerationSpeed;  
        
        SpeedTurn = character.SpeedTurn;
        SpeedWalk = character.SpeedWalk;
        SpeedRun = character.SpeedRun;
        SpeedCurve = character.SpeedCurve;
        
        HitDamage = character.HitDamage;
        HitDamageSpeed = character.HitSpeed;
        HitDamageRadius = character.HitRadius;
    }
}
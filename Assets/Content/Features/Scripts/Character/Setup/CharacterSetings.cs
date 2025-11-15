using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSetings", menuName = "Character/CharacterSetings")]
public class CharacterSetings : ScriptableObject
{
    [Header("Character")]
    [SerializeField] private GameObject model;
    public GameObject Model => model;
    
    [Header("Health")]
    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;
    [SerializeField] private float regenerationSpeed;
    public float RegenerationSpeed => regenerationSpeed;

    [Header("Speed")]
    [SerializeField] private float speedTurn;
    public float SpeedTurn => speedTurn;
    [SerializeField] private float speedWalk;
    public float SpeedWalk => speedWalk;
    [SerializeField] private float speedRun;
    public float SpeedRun => speedRun;
    [SerializeField] private AnimationCurve speedCurve;
    public AnimationCurve SpeedCurve => speedCurve;
    
    [Header("Hit")]
    [SerializeField] private int hitDamage;
    public int HitDamage => hitDamage;
    [SerializeField] private float hitSpeed;
    public float HitSpeed => hitSpeed;
    [SerializeField] private float hitRadius;
    public float HitRadius => hitRadius;
    
    
    
}

using UnityEngine;

public interface ICharacter
{
    public int HealthCurrent { get; set;}
    public int HealthMax { get; set; }
    public float RegenerationSpeed { get; set; }
    public void Regeneration();
    
    public void Damage(int damage);
    public bool Heal(int heal);
    public void Die();
    
    public int FoodCurrent { get; set; }
    public bool Eat(int food);
   

}

public interface IHealse
{
   public int Healse { get; set; }
   public int HealseMax { get; set; }
   public int Regen { get; set; }
   public void Healsed(int healse);
   public void Hit(int Damage);
   public void Die();
}

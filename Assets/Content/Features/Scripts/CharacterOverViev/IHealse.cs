public interface IHealse
{
    public int MaxHealse { get; set; }
    public int Healse { get; set; }
    public int RegenerationSpeed { get; set; }
    
    public void Healsed(int healsed);
    public void Hit(int damage);
    
    public void Die();
}

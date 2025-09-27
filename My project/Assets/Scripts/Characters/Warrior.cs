using UnityEngine;

public class Warrior : MonoCharacter
{
   public override void Death()
   {
      GetComponent<Animator>().SetTrigger("Death");
      Debug.Log("Warrior is dead");
      Destroy(gameObject, 5f);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoCharacter
{
    protected override void DisplayHand()
    {
        //base.DisplayHand();
        Destroy(handTransform.GetComponentInChildren<Item>().gameObject);
    }
}

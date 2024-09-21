using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a temporary Class, we make many prefabs, one per card or smthg
public class BlankCard : BaseCard
{
    void INIT(bool IntoDeck)
    {
        base.INIT(IntoDeck);
    }
    
    public override void CardAction()
    {
        if (Upgraded)
        {
            
        }
        else
        {
            GameManager.Instance.ModifyPrice(Random.Range(-0.9999f,0.9999f));
        }
    }
    
}

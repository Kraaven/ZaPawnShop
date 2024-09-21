using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertCard : BaseCard
{
    void Start()
    {
        base.Start();
    }

    public override void CardAction()
    {
        if (Upgraded)
        {
            
        }
        else
        {
            if (Random.value < 0.5)
            {
                GameManager.Instance.ModifyPrice(0.5f);
                print("An Expert says this it worthless");
            }
            else
            {
                GameManager.Instance.ModifyPrice(1);
                print("An Expert says this very valuable");
            }
            
        }
    }
}

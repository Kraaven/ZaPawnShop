using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeModify : BaseCard
{

    public int PercentageChange;
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
            GameManager.Instance.ModifyPrice(((float)PercentageChange)/100);
            print($"Alright!, {PercentageChange} is pretty good!");
        }
    }
}

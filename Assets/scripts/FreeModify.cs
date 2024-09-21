using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeModify : BaseCard
{

    public int PercentageChange;
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
            GameManager.Instance.ModifyPrice(((float)PercentageChange)/100);
            print($"Alright!, {PercentageChange} is pretty good!");
        }
    }
}

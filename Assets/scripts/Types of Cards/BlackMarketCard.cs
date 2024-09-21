using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMarketCard : BaseCard
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
            GameManager.Instance.ModifyPrice(0.2f);
        }
    }
}

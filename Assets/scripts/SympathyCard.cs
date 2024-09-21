using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SympathyCard : BaseCard
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
            print("Please Sympathise and give me 20%");
            GameManager.Instance.AddFutureEvent(4, () =>
            {
                GameManager.Instance.ModifyPrice(-0.2f);
                print("Cut the fake ass Sympathy Shit, gimme my 20%");
            });
        }
    }
}

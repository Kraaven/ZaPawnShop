using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatigueCard : BaseCard
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
            print("Dont you think this is taking too long?");
            GameManager.Instance.AddFutureEvent(3, () =>
            {
                GameManager.Instance.ModifyPrice(0.15f);
                print("This has been going on for long enough...");
            });
        }
    }
}

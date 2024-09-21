using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationCard : BaseCard
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
            print("Aight, Lets start Talking");
            GameManager.Instance.AddFutureEvent(2, () =>
            {
                GameManager.Instance.ModifyPrice(0.02f);
                print("Conversed another 2%");
            });
            
            GameManager.Instance.AddFutureEvent(3, () =>
            {
                GameManager.Instance.ModifyPrice(0.02f); 
                print("Conversed another 2%");
            });
            
            GameManager.Instance.AddFutureEvent(4, () =>
            {
                GameManager.Instance.ModifyPrice(0.02f); 
                print("Conversed another 2%");
            });
        }
    }
}

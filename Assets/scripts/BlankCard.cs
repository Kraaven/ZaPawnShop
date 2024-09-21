using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a temporary Class, we make many prefabs, one per card or smthg
public class BlankCard : BaseCard
{
    void Start()
    {
        //Do all the basic stuff that all cards gotta do
        base.Start();
    }

    public override void CardAction()
    {
        if (Upgraded)
        {
            
        }
        else
        {
            print($"Hello World {Random.Range(0,100)}");

            if (GameManager.Instance.TurnCounter == 0)
            {
                GameManager.Instance.AddFutureEvent(2, HelloFuture);
            }
        }
    }

    public void HelloFuture()
    {
        print("YOO, Hello Future!");
    }
}

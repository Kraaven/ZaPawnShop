using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNegotiationCard : BaseCard
{
    // Start is called before the first frame update

    private int endTurnChance;
    

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
            endTurnChance = UnityEngine.Random.Range(0,2);
            
            
            if(endTurnChance == 0)
            {
                Debug.Log("Kal");
            }
            else
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}

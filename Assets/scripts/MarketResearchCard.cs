using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketResearchCard : BaseCard
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
            if (GameManager.Instance.NegotiationPrice > GameManager.Instance.BasePrice)
            {
                GameManager.Instance.NegotiationPrice = (int)(GameManager.Instance.NegotiationPrice *(0.8f));
                FindObjectOfType<PriceIndicator>().MoveToNewValue(GameManager.Instance.NegotiationPrice);
                print("Research indicates this is worth lesser");
            }
            else
            {
                GameManager.Instance.NegotiationPrice = (int)(GameManager.Instance.NegotiationPrice *(1.2f));
                FindObjectOfType<PriceIndicator>().MoveToNewValue(GameManager.Instance.NegotiationPrice);
                print("Research indicates this is worth more");
            }
        }
    }
}

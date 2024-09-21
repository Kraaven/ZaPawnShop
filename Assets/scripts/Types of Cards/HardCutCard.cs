using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCutCard : BaseCard
{
    // Start is called before the first frame update
    private int randomCardToDestroy;
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

            List<BaseCard> cards = GameObject.Find("MyDeck").GetComponent<Positions>().PlayerCards;

            BaseCard deletecard = cards[Random.Range(0, cards.Count)];

            cards.Remove(deletecard);
            
            CardHolder.Instance.ReturnCardToPossibilities(deletecard.name);
            Destroy(deletecard.gameObject);
            GameManager.Instance.ModifyPrice(0.3f);
            

        }
    }
}

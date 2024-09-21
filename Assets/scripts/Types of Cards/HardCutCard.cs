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
            randomCardToDestroy = UnityEngine.Random.Range(0,MyDeckCards.Count);

            for(int i = 0; i < MyDeckCards.Count; i++)
            {
                Debug.Log("" + MyDeckCards[i]);
            }
            
            GameManager.Instance.ModifyPrice(-0.3f);
            if(MyDeckCards[randomCardToDestroy].name != "Hard Cut")
            {
                MyDeckCards[randomCardToDestroy].SetActive(false);
                MyDeckCards.Remove(MyDeckCards[randomCardToDestroy]);
            }
            
        }
    }
}

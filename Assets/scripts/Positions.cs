using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Positions : MonoBehaviour
{
    //All the positions for this set of cards
    public List<GameObject> CardPositions;
    public int EmptyPosition = 0;
    //check if this set of positions is  a deck, or the initial choice picker
    public bool deck;
    
    

    //What is called when a card is spawned, or clicked on
    public void InsertCard(BaseCard card)
    {
        if (!deck)
        {
            //going into the Initial Card positions
            card.transform.DOMove(CardPositions[EmptyPosition].transform.position, 1f);
            card.transform.DOScale(card.transform.localScale * 0.65f, 1f);
            EmptyPosition++;
        }
        else
        {
            //going into the player deck
            card.transform.DOMove(CardPositions[EmptyPosition].transform.position, 0.45f);
            card.transform.DOScale(Vector3.one, 0.45f);
            EmptyPosition++;

            if (EmptyPosition == 5)
            {
                //Delete all the extra unpicked cards
                StartCoroutine(DeleteExtraCards());
            }
        }
    }

    IEnumerator DeleteExtraCards()
    {
        Cursor.lockState = CursorLockMode.Locked;
        foreach (var card in FindObjectsOfType<BaseCard>())
        {
            if (!card.CardCollected)
            {
                card.transform.DOScale(Vector3.one * 0.05f, 0.1f).OnComplete(() =>
                {
                    Destroy(card.gameObject);
                }); 
            }
            
        }

        yield return new WaitForSeconds(0.4f);
        Cursor.lockState = CursorLockMode.None;
    }
}

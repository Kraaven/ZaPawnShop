using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour, IPointerClickHandler
{
    //Bools for if the card is collected or upgraded
    public bool CardCollected;
    public bool Upgraded;
    public bool CardUsed;
    public int DeckPosition;

    public void Start()
    {
        //Insert the card into the starter picking options
        GameObject.Find("OfferedCards").GetComponent<Positions>().InsertCard(this);
    }

    //TO BE OVERWRITTEN IN A CHILD CLASS
    //What Action the card does. Make sure to remember that upgraded matters
    public virtual void CardAction()
    {
        //You will have to reimplement this upgraded if statement, its merely the structure of ur code
        if (Upgraded)
        {
            
        }
        else
        {
            
        }
    }

    
    //When the Card if clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if ( eventData.button == PointerEventData.InputButton.Left && !CardUsed)
        {
            //If the card was already collected, this yea, perform the action
            if (CardCollected && GameManager.PlayerTurn)
            {
                // CardAction();
                Sequence ActionSequence = DOTween.Sequence();
                GameManager.PlayerTurn = false;
                ActionSequence.Append(transform.DOMove(CardHolder.PlayPosition.position, 1.5f).SetEase(Ease.OutQuart).OnComplete(
                    () =>
                    {
                        CardAction();
                    }));
                ActionSequence.AppendInterval(1.5f);
                ActionSequence.Append(transform.DOMove(CardHolder.LastUsedPosition.position, 0.75f)); 
                ActionSequence.Append(CardHolder.LastUsedCard.transform.DOScale(Vector3.one * 0.05f, 0.1f).OnComplete(
                    () =>
                    {
                        if (CardHolder.LastUsedCard != null)
                        {
                            Destroy(CardHolder.LastUsedCard.gameObject);
                        }
                        CardHolder.LastUsedCard = this;
                        CardUsed = true;
                    }));

            }
            else
            {
                //Collect it from the list of options
                CardCollected = true;
                GameObject.Find("MyDeck").GetComponent<Positions>().InsertCard(this);
            }
        }
    }
    
    
}

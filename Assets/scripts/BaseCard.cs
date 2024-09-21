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
        if (eventData.button == PointerEventData.InputButton.Left && !CardUsed)
        {
            // Check if it's the Preturn phase (collecting cards)
            if (GameManager.Preturn)
            {
                if (!CardCollected)
                {
                    // Collect the card if it's not collected yet
                    CardCollected = true;
                    GameObject.Find("MyDeck").GetComponent<Positions>().InsertCard(this);
                }
            }
            // Otherwise, it's the player's turn (use cards)
            else if (CardCollected && GameManager.PlayerTurn)
            {
                UseCard();
            }
        }
    }

    // Method to handle card usage
    private void UseCard()
    {
        GameManager.PlayerTurn = false;
        
        // Create a sequence of actions with DOTween
        Sequence actionSequence = DOTween.Sequence();
        actionSequence.Append(transform.DOMove(CardHolder.PlayPosition.position, 1.5f).SetEase(Ease.OutQuart)
            .OnComplete(() => CardAction()));

        actionSequence.AppendInterval(1.5f);

        actionSequence.Append(transform.DOMove(CardHolder.LastUsedPosition.position, 0.75f));
        actionSequence.Append(CardHolder.LastUsedCard.transform.DOScale(Vector3.one * 0.05f, 0.1f).OnComplete(() =>
        {
            if (CardHolder.LastUsedCard != null)
            {
                Destroy(CardHolder.LastUsedCard.gameObject);
            }

            CardHolder.LastUsedCard = this;
            CardUsed = true;
        }));
    }
    
    
}

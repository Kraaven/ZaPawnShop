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

    public HardCutCard hardCutCard;

    
    public void INIT(bool IntoDeck)
    {
        //Insert the card into the starter picking options

        if (!IntoDeck)
        {
            GameObject.Find("OfferedCards").GetComponent<Positions>().InsertCard(this);
        }
        else
        {
            GameObject.Find("MyDeck").GetComponent<Positions>().InsertCard(this);
            CardCollected = true;
        }
        
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
                    Debug.Log("Added + " + gameObject.name + "to mydecks list");
                    hardCutCard.MyDeckCards.Add(gameObject);
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
        actionSequence.AppendInterval(0.2f).OnComplete(() =>
        {
            if (CardHolder.LastUsedCard != null)
            {
                // Return the card to possibilities before destroying it
                CardHolder.Instance.ReturnCardToPossibilities(CardHolder.LastUsedCard.name);
                Destroy(CardHolder.LastUsedCard.gameObject);
                for(int i = 0; i < hardCutCard.MyDeckCards.Count; i++)
                {
                    if(hardCutCard.MyDeckCards[i].name == gameObject.name)
                    {
                        Debug.Log("DESTROYING: " + hardCutCard.MyDeckCards[i].name );
                        Destroy(hardCutCard.MyDeckCards[i]);
                    }
                }
            }

            CardHolder.LastUsedCard = this;
            CardUsed = true;
            
            GameManager.EndPlayerTurn();
        });

    }
    
    
}

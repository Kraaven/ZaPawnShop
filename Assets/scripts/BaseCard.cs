using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour, IPointerClickHandler
{
    public bool CardCollected;
    public bool Upgraded;

    public void Start()
    {
        print("starting Movement");
        GameObject.Find("OfferedCards").GetComponent<Positions>().InsertCard(this);
    }

    public virtual void CardAction()
    {
        if (Upgraded)
        {
            
        }
        else
        {
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (CardCollected)
            {
                CardAction();
            }
            else
            {
                CardCollected = true;
                GameObject.Find("MyDeck").GetComponent<Positions>().InsertCard(this);
            }
        }
    }
}

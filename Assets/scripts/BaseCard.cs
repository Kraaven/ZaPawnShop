using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour, IPointerClickHandler
{
    //Bools for if the card is collected or upgraded
    public bool CardCollected;
    public bool Upgraded;

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
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //If the card was already collected, this yea, perform the action
            if (CardCollected)
            {
                CardAction();
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

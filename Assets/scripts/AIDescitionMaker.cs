using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIDescitionMaker : MonoBehaviour
{
    [SerializeField]private CardHolder _cardHolder;
    [SerializeField] private List<GameObject> Selerdeck = new List<GameObject>();
    [SerializeField] private Transform playCardPosition;
    [SerializeField] private List<string> CardsIgotbyName;
    [SerializeField] private Transform CanvasCalledGameSYSTEM;

    private void Start()
    {
       print("Seller is choosing a deck");
       for (int i = 0; i < 5 ; i++)
       {
           Selerdeck.Add(_cardHolder.CardDictionary[_cardHolder.DeckPossibilities[Random.Range(0, 8)]]);
       }

       foreach (var card in Selerdeck)
       {
           Instantiate(card, transform);
           // card.GetComponent<BaseCard>().CardCollected = true;
       }
    }

    public void SellerCardPlay()
    {
        int curCard = Random.Range(0, 5);
        Selerdeck[curCard].transform.DOMove(playCardPosition.position, 1.5f).SetEase(Ease.OutQuart);
        Selerdeck[curCard].GetComponent<BaseCard>().CardAction();
        Selerdeck.RemoveAt(curCard);
        
    }
}

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
           int randomIndex = Random.Range(0, CardHolder.Instance.DeckPossibilities.Count);
           string cardName = CardHolder.Instance.DeckPossibilities[randomIndex];
           
           
           //Check if that name is inside the Dictionary
           if (CardHolder.Instance.CardDictionary.TryGetValue(cardName, out GameObject cardPrefab))
           {
               // Instantiate the card
               GameObject cardInstance = Instantiate(cardPrefab, transform.position, transform.rotation, FindObjectOfType<Canvas>().transform);
               cardInstance.name = cardPrefab.name;
               cardInstance.GetComponent<BaseCard>().INIT(true);
               // Remove the card name from DeckPossibilities
               CardHolder.Instance.DeckPossibilities.RemoveAt(randomIndex);

               cardInstance.GetComponent<BaseCard>().CardCollected = true;
           }
           else
           {
               Debug.LogError($"Card prefab '{cardName}' not found in CardDictionary.");
           }
       }

       // foreach (var card in Selerdeck)
       // {
       //     Instantiate(card, transform);
       //     // card.GetComponent<BaseCard>().CardCollected = true;
       // }
    }

    public void SellerCardPlay()
    {
        int curCard = Random.Range(0, 5);
        Selerdeck[curCard].transform.DOMove(playCardPosition.position, 1.5f).SetEase(Ease.OutQuart);
        Selerdeck[curCard].GetComponent<BaseCard>().CardAction();
        Selerdeck.RemoveAt(curCard);
        
    }
}

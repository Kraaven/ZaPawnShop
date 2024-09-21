using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardHolder : MonoBehaviour
{
    public static CardHolder Instance;
    
    public Canvas Canvas;
    public Positions PlayerDeck;
    public GameObject LastCard;
    public static Transform PlayPosition;
    public static BaseCard LastUsedCard;
    public static Transform LastUsedPosition;

    // Dictionary to hold all card prefabs, keyed by their names
    public Dictionary<string, GameObject> CardDictionary = new Dictionary<string, GameObject>();
    
    // List of card names that can be instantiated
    public List<string> DeckPossibilities = new List<string>();

    private void Awake()
    {
        Instance = this;
        InitializeCardDictionary();
    }

    private void InitializeCardDictionary()
    {
        // Assuming all card prefabs are in a "Cards" folder in Resources
        GameObject[] cardPrefabs = Resources.LoadAll<GameObject>("Cards");
        foreach (GameObject prefab in cardPrefabs)
        {
            CardDictionary[prefab.name] = prefab;
            DeckPossibilities.Add(prefab.name);
        }
    }

    IEnumerator Start()
    {
        PlayPosition = GameObject.Find("PlayCardPosition").transform;
        LastUsedPosition = GameObject.Find("LastUsedPosition").transform;
        LastUsedCard = LastCard.GetComponent<BaseCard>();

        yield return new WaitForSeconds(0.2f);
        
        // Create 5 cards to choose from
        for (int i = 0; i < 8; i++)
        {
            SpawnCard();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void SpawnCard()
    {
        if (DeckPossibilities.Count > 0)
        {
            int randomIndex = Random.Range(0, DeckPossibilities.Count);
            string cardName = DeckPossibilities[randomIndex];
            
            if (CardDictionary.TryGetValue(cardName, out GameObject cardPrefab))
            {
                // Instantiate the card
                GameObject cardInstance = Instantiate(cardPrefab, transform.position, transform.rotation, Canvas.transform);
                cardInstance.name = cardPrefab.name;
                // Remove the card name from DeckPossibilities
                DeckPossibilities.RemoveAt(randomIndex);
            }
            else
            {
                Debug.LogError($"Card prefab '{cardName}' not found in CardDictionary.");
            }
        }
        else
        {
            Debug.LogWarning("No more cards available to spawn.");
        }
    }

    public void ReturnCardToPossibilities(string cardName)
    {
        if (CardDictionary.ContainsKey(cardName) && !DeckPossibilities.Contains(cardName))
        {
            // Add the card name back to DeckPossibilities
            DeckPossibilities.Add(cardName);
        }
        else
        {
            Debug.LogWarning($"Attempted to return non-existent or already available card: {cardName}");
        }
    }
}
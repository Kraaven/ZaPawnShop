using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool PlayerTurn;
    public static bool Preturn = true;
    public static bool AI_Turn;
    

    public bool SkipBot;
    public int BasePrice = 200;
    public int NegotiationPrice;
    public int TurnCounter;
    public bool EndNegotiation;
    public List<FutureEvent> Events;
    
    [SerializeField] private PriceIndicator _priceIndicator; 
    
    private void Awake()
    {
        Instance = this;
    }

    public void INIT()
    {
        List<float> askingPriceArray = new List<float>();
        askingPriceArray.Add(BasePrice * 1.1f);
        askingPriceArray.Add(BasePrice * 1.35f);
        askingPriceArray.Add(BasePrice / 1.35f);
        askingPriceArray.Add(BasePrice / 1.1f);
        
        NegotiationPrice = (int)askingPriceArray[Random.Range(0, 3)]; 
        Events = new List<FutureEvent>();
        StartCoroutine(GameLoop());
        _priceIndicator.MoveToNewValue(NegotiationPrice);
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(MainGamePhase());
        EndGame();
    }
    

    //Main Gameplay loop
    private IEnumerator MainGamePhase()
    {
        Debug.Log("Starting Main Game Phase");
        TurnCounter = 0;
        
        while (!EndNegotiation)
        {
            yield return StartCoroutine(PlayerTurnCoroutine());
            if (!SkipBot) yield return StartCoroutine(BotTurnCoroutine());
            
            TurnCounter++;
            yield return StartCoroutine(ProcessFutureEvents());
        }
    }

    private IEnumerator PlayerTurnCoroutine()
    {
        Debug.Log("Player's Turn");
        PlayerTurn = true;
        // Wait for the player to use a card
        yield return new WaitUntil(() => AI_Turn);
    }

    private IEnumerator BotTurnCoroutine()
    {
        Debug.Log("Bot's Turn");
        yield return null; // Give a frame for any UI updates
        print("BOT DOING SHIT");
        yield return new WaitForSeconds(1);
        BotTurn();
    }

    private void BotTurn()
    {
        AI_Turn = false;


    }

    private IEnumerator ProcessFutureEvents()
    {
        if (Events.Count == 0) yield break;
            
        foreach (var evt in Events.ToList())
        {
            evt.UpdateActivity();
            if (evt.TurnCount <= 0)
            {
                evt.FutureActivity?.Invoke();
                Events.Remove(evt);
            }
        }
        yield return null;
    }

    private void EndGame()
    {
        Debug.Log("Game Over");
    }

    // Method to add new future events
    public void AddFutureEvent(int turns, System.Action action)
    {
        Events.Add(new FutureEvent(turns, action));
    }

    // Call this method when a card action is completed
    public static void EndPlayerTurn()
    {
        AI_Turn = true;
    }
}

//The whole Future Event Class
public class FutureEvent
{
    public Action FutureActivity { get; private set; }
    public int TurnCount { get; private set; }

    public FutureEvent(int turns, Action behavior)
    {
        if (turns < 0)
        {
            Debug.LogWarning("FutureEvent created with negative turn count. Setting to 0.");
            turns = 0;
        }

        TurnCount = turns;
        FutureActivity = behavior ?? throw new ArgumentNullException(nameof(behavior));
    }

    public void UpdateActivity()
    {
        if (TurnCount > 0)
        {
            TurnCount--;
        }
    }
    

    public bool IsCompleted => TurnCount == 0;
}


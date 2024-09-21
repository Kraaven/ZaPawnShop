using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    public GameObject BlankPrefab;
    public Canvas Canvas;

    public Positions PlayerDeck;
    public GameObject LastCard;
    public static Transform PlayPosition;
    public static BaseCard LastUsedCard;
    public static Transform LastUsedPosition;

    public List<BaseCard> AvailableCards;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        PlayPosition = GameObject.Find("PlayCardPosition").transform;
        LastUsedPosition = GameObject.Find("LastUsedPosition").transform;
        LastUsedCard = LastCard.GetComponent<BaseCard>();
        
        //Wait for a bit for everything to initialize
        yield return new WaitForSeconds(0.2f);
        
        
        //Creating 8 cards to chose from, this will later be a random choice from a list of prefabs
        for (int i = 0; i < 8; i++)
        {
            Instantiate(BlankPrefab, transform.position, transform.rotation, Canvas.transform);
            yield return new WaitForSeconds(0.2f);
        }
        
        FindObjectOfType<GameManager>().INIT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

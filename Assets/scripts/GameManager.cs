using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int BasePrice;
    public int NegotiationPrice;

    public static bool PlayerTurn;
    void Start()
    {
        PlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

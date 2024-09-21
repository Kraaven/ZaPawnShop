using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int BasePrice;
    public int NegotiationPrice;

    public static bool PlayerTurn;
    public static bool Preturn = true;
    public void INIT()
    {
        PlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Temp so that we can actually change turns manually
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTurn = true;
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Positions : MonoBehaviour
{
    public List<GameObject> CardPositions;
    public int EmptyPosition = 0;
    public bool deck;
    
    

    public void InsertCard(BaseCard card)
    {
        if (!deck)
        {
            card.transform.DOMove(CardPositions[EmptyPosition].transform.position, 1f);
            card.transform.DOScale(card.transform.localScale * 0.65f, 1f);
            EmptyPosition++;
        }
        else
        {
            card.transform.DOMove(CardPositions[EmptyPosition].transform.position, 0.45f);
            card.transform.DOScale(Vector3.one, 0.45f);
            EmptyPosition++;

            if (EmptyPosition == 5)
            {
                StartCoroutine(DeleteExtraCards());
            }
        }
    }

    IEnumerator DeleteExtraCards()
    {
        Cursor.lockState = CursorLockMode.Locked;
        foreach (var card in FindObjectsOfType<BaseCard>())
        {
            if (!card.CardCollected)
            {
                card.transform.DOScale(Vector3.one * 0.05f, 0.1f).OnComplete(() =>
                {
                    Destroy(card.gameObject);
                }); 
            }
            
        }

        yield return new WaitForSeconds(0.1f);
        Cursor.lockState = CursorLockMode.None;
    }
}

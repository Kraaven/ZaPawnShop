using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public GameObject BlankPrefab;
    public Canvas Canvas;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        Canvas = FindObjectOfType<Canvas>();
        for (int i = 0; i < 8; i++)
        {
            Instantiate(BlankPrefab, transform.position, transform.rotation, Canvas.transform);
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

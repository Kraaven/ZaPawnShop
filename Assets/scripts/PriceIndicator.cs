using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PriceIndicator : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private TMP_Text askingPriceTMP;

    private int UppercapMultiplier = 3; 
    void Start()
    {
        UppercapMultiplier = Random.Range(3, 5);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            MoveToNewValue(_gameManager.NegotiationPrice);
        }
    }

    public void MoveToNewValue(int newAskingPrice)
    {
        float endVal = Mathf.InverseLerp( _gameManager.BasePrice * UppercapMultiplier,0f,  newAskingPrice);
        DOTween.To(() => _scrollbar.value, x => _scrollbar.value = x, endVal, 0.75f);
        DOTween.To(()=> askingPriceTMP.text, x=> askingPriceTMP.text = x, newAskingPrice.ToString(), 0.75f)
            .SetOptions(true, ScrambleMode.All);
    }

}
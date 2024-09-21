using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PriceIndicator : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private TMP_Text askingPriceTMP;

    private int UppercapMultiplier = 2; 
    void Start()
    {
        DOTween.Init();
        UppercapMultiplier = Random.Range(2, 4);
    }

    public void MoveToNewValue(int newAskingPrice)
    {
        float endVal = Mathf.InverseLerp(_gameManager.BasePrice * UppercapMultiplier, 0f, newAskingPrice);
        DOTween.To(() => _scrollbar.value, x => _scrollbar.value = x, endVal, 0.75);
    }
}

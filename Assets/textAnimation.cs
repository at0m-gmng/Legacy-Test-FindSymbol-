using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private float fadeTime; // время появления
    private TextMeshProUGUI textWithData; // текстовое поле с данными

    private void Start()
    {
        textWithData = GetComponentInChildren<TextMeshProUGUI>();
        FadeIn();
    }
    private void FadeIn()
    {
        textWithData.DOFade(0, fadeTime).From();
    }
}

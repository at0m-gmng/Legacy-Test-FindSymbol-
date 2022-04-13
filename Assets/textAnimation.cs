using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class textAnimation : MonoBehaviour
{
    [SerializeField] private float fadeTime; // время появления
    private TextMeshProUGUI textWithData; // текстовое поле с данными

    private void Awake()
    {
        textWithData = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        fadeIn();
    }
    private void fadeIn()
    {
        textWithData.DOFade(0, fadeTime).From();
    }
}

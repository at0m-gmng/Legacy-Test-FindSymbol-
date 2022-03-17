using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class textAnimation : MonoBehaviour
{
    private Sequence sequence; // переменная для очереди
    [SerializeField] private float fadeTime; // время появления
    private TextMeshProUGUI tm;

    private void Awake()
    {
        tm = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        fadeIn(gameObject);
    }
    private void fadeIn(GameObject gameObject)
    {
        tm.DOFade(0, fadeTime).From();
    }
}

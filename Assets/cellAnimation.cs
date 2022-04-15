using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellAnimation : MonoBehaviour
{
    private Vector2 normalScale;
    private Vector2 clickedScale;

    private Sequence sequence; // переменная для очереди
    [SerializeField] private float scaleTime; // duration для easeInBounce
    [SerializeField] private float bounceScaleTime; // duration для bounce
    private gameStateContoller gameStateContoller;

    private void Awake()
    {
        normalScale = transform.localScale;
        clickedScale = new Vector2(normalScale.x - .05f, normalScale.y - .05f);
    }

    private void Start()
    {
        gameStateContoller = FindObjectOfType<gameStateContoller>();
        BounceInAnimation();
    }

    private void OnMouseDown()
    {
        transform.localScale = clickedScale;
    }

    private void OnMouseUp()
    {
        transform.localScale = normalScale;

        if (gameStateContoller.lose)
            EaseInBounceAnimation();
        else if (gameStateContoller.win)
            BounceInAnimation();
    }

    private void BounceInAnimation()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.0f, bounceScaleTime))
                .Append(transform.DOScale(1.2f, bounceScaleTime))
                .Append(transform.DOScale(.95f, bounceScaleTime))
                .Append(transform.DOScale(1f, bounceScaleTime));
    }
    private void EaseInBounceAnimation()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.0f, scaleTime))
                .Append(transform.DOScale(.11f, scaleTime))
                .Append(transform.DOScale(.44f, scaleTime))
                .Append(transform.DOScale(.98f, scaleTime))
                .Append(transform.DOScale(.75f, scaleTime))
                .Append(transform.DOScale(.98f, scaleTime))
                .Append(transform.DOScale(.94f, scaleTime))
                .Append(transform.DOScale(.99f, scaleTime))
                .Append(transform.DOScale(.98f, scaleTime))
                .Append(transform.DOScale(1f, scaleTime));
    }
}

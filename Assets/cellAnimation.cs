using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cellAnimation : MonoBehaviour
{
    //private gameStateContoller gameStateContoller = new gameStateContoller();
    //private Cell cell;


    private Vector2 normalScale;
    private Vector2 clickedScale;

    private Sequence sequence; // переменная для очереди
    [SerializeField] private float scaleTime;
    [SerializeField] private float bounceScaleTime;

    private void Awake()
    {

        normalScale = transform.localScale;
        clickedScale = new Vector2(normalScale.x - .05f, normalScale.y - .05f);
        //BounceInAnimation(gameObject);
        gameStateContoller gameStateContoller = FindObjectOfType<gameStateContoller>();
    }

    private void Start()
    {
        BounceInAnimation();
    }

    private void OnMouseDown()
    {
        // Проверяем в gameStateContoller соответствует ли name Find X , после чего вызываем соответствующую анимацию
        //Debug.Log("pressDown");
        transform.localScale = clickedScale;

        //gameStateContoller.stateCheck = true;

        //easeInBounceAnimation();
        //BounceInAnimation(gameObject);
    }

    private void OnMouseUp()
    {
        //Debug.Log("pressUp");
        transform.localScale = normalScale;

        if (gameStateContoller.lose)
            easeInBounceAnimation();
        else if (gameStateContoller.win)
            BounceInAnimation();
    }

    //public void stateAnimation(string state)
    //{
    //    if (state == "lose")
    //        Debug.Log("lose");
    //        //easeInBounceAnimation();
    //}

    public void BounceInAnimation()
    {
        //cell = cell;
        sequence = DOTween.Sequence();
        // панелька немного увеличив, меняет своё значение на новое и возращает исходный размер
        sequence.Append(transform.DOScale(0.0f, bounceScaleTime))
                .Append(transform.DOScale(1.2f, bounceScaleTime))
                .Append(transform.DOScale(.95f, bounceScaleTime))
                .Append(transform.DOScale(1f, bounceScaleTime));
    }
    /*
    private void BounceOutAnimation()
    {
        sequence = DOTween.Sequence();
        // панелька немного увеличив, меняет своё значение на новое и возращает исходный размер
        sequence
                .Append(transform.DOScale(1f, scaleTime))
                .Append(transform.DOScale(.95f, scaleTime))
                .Append(transform.DOScale(1.2f, scaleTime))
                .Append(transform.DOScale(0.0f, scaleTime));
    }
    */

    private void easeInBounceAnimation()
    {
        sequence = DOTween.Sequence();
        // панелька немного увеличив, меняет своё значение на новое и возращает исходный размер
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

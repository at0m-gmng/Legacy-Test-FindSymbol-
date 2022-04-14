using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Image blackoutPanel; //панель для затемнения
    [SerializeField] private gameStateContoller gameStateContoller;
    [SerializeField] private GameObject restartButton; // кнопка рестарта
    [SerializeField] private float fadeTime = 1; // время появления

    private void Start()
    {
        restartButton.SetActive(false);
        Fade(0, fadeTime, false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(gameStateContoller.stopGame)
        {
            Time.timeScale = 0;
            Fade(255, fadeTime, true);
            restartButton.SetActive(true);
        }
    }

    //перезапуск сцены при нажатии на кнопку рестарт
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //затемняем или осветляем панель в зависимости от передаваемых данных
    private void Fade(int endValue, float duration, bool blackout)
    {
        if(blackout)
            blackoutPanel.DOFade(endValue, duration).From();
        else
            blackoutPanel.DOFade(endValue, duration);
    }

}

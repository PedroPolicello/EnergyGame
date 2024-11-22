using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fade;
    [SerializeField] private CanvasGroup startButton;
    [SerializeField] private CanvasGroup exitButton;
    [SerializeField] private GameObject title;
    [SerializeField] private float duration;

    private void Start()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(.5f);
        title.transform.DOMoveX(600, 2.5f);
        yield return new WaitForSeconds(1);
        startButton.DOFade(1, duration);
        exitButton.DOFade(1, duration);
        yield return new WaitForSeconds(duration);
    }

    public void CallPlayGame()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(.5f);
        title.transform.DOMoveY(1500, 2.5f);
        startButton.DOFade(0, 4);
        exitButton.DOFade(0, 4);
        yield return new WaitForSeconds(4);
        fade.DOFade(1, duration);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        print("exiting...");
        Application.Quit();
    }
}

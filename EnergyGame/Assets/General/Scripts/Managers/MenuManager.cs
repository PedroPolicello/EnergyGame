using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fade;
    [SerializeField] private float duration;

    public void CallPlayGame()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
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

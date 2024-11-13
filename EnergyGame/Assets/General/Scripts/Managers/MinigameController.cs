using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class MinigameController : MonoBehaviour
{
    [Header("Minigame Objects")]
    [SerializeField] private GameObject biomassMinigame;
    [SerializeField] private GameObject hidricMinigame;
    [SerializeField] private GameObject xMinigame;

    [Header("Player Pos")]
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 biomassPos;
    [SerializeField] private Vector2 hidricPos;
    [SerializeField] private Vector2 xPos;

    [Header("Other Info")]
    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float fadeDuration;
    [SerializeField] private CanvasGroup fade;

    [Header("Verification Info")] 
    public bool fadeFinished = true;
    public bool biomassFinished;
    public bool hidricFinished;

    [Header("Generator Info")] 
    [SerializeField] private GameObject biomass;
    [SerializeField] private GameObject hidric;
    [SerializeField] private GameObject x;

    public void BiomassMinigame(bool isStarting)
    {
        if (isStarting && fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(biomassPos, 1, 0)); 
        }
        else if (!isStarting && fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(startPos, 0, 1));
            biomassMinigame.SetActive(false);
        }
        else return;
    }

    IEnumerator FadeTo(Vector2 position, int index, int minigameCompleted)
    {
        GameManager.Instance.InputManager.DisableMovement();
        fade.DOFade(1, fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
        cam.ForceCameraPosition(position, Quaternion.identity);
        player.transform.position = position;
        fade.DOFade(0, fadeDuration * 2);
        yield return new WaitForSeconds(fadeDuration);

        switch (index)
        {
            case 0:
                FarmUpdate(minigameCompleted);
                break;
            
            case 1:
                GameManager.Instance.uiManager.CallCountdown();
                break;
            
            default:
                break;
        }
    }

    void FarmUpdate(int index)
    {
        switch (index)
        {
            case 1:
                biomassFinished = true;
                biomass.GetComponent<Interactable>().isComplete = true;
                break;
            
            case 2:
                hidricFinished = true;
                hidric.GetComponent<Interactable>().isComplete = true;
                break;
            
            default:
                break;
        }
        
        fadeFinished = true;
        GameManager.Instance.InputManager.EnableMovement();
        player.GetComponent<PlayerControl>().speed = 8;
        cam.Follow = player.transform;
        cam.LookAt = player.transform;
    }

    public void StartBiomass()
    {
        fadeFinished = true;
        GameManager.Instance.InputManager.EnableMovement();
        biomassMinigame.SetActive(true);
        player.GetComponent<PlayerControl>().speed = 13;
        cam.Follow = null;
        cam.LookAt = null;
    }
    
}
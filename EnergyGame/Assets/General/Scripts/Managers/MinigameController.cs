using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class MinigameController : MonoBehaviour
{
    [Header("Minigame Objects")]
    [SerializeField] private GameObject[] biomassMinigame;
    [SerializeField] private GameObject[] hidricMinigame;
    [SerializeField] private GameObject[] eolicMinigame;

    [Header("Player Pos")]
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 biomassPos;
    [SerializeField] private Vector2 hidricPos;
    [SerializeField] private Vector2 eolicPos;

    [Header("Other Info")]
    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float fadeDuration;
    [SerializeField] private CanvasGroup fade;

    [Header("Verification Info")] 
    public bool fadeFinished = true;
    public bool biomassFinished;
    public bool hidricFinished;
    public bool eolicFinished;

    [Header("Generator Info")] 
    public GameObject biomass;
    public GameObject hidric;
    public GameObject eolic;

    [Header("Tutorial Minigame")]
    [TextArea(3,3)] public string biomassTutorial;
    public float biomassTutorialDuration;
    [TextArea(2,3)] public string hidricTutorial;
    public float hidricTutorialDuration;
    [TextArea(2,3)] public string eolicTutorial;
    public float eolicTutorialDuration;

    [Header("Tutorial Inicial")]
    [TextArea(4,3)] public string initialTutorial;
    public float InitialTutorialDuration;


    private void Awake()
    {
        for (int i = 0; i < biomassMinigame.Length; i++)
        {
            biomassMinigame[i].SetActive(false);
        }
        for (int i = 0; i < hidricMinigame.Length; i++)
        {
            hidricMinigame[i].SetActive(false);
        }    
        for (int i = 0; i < eolicMinigame.Length; i++)
        {
            eolicMinigame[i].SetActive(false);
        }

        fade.alpha = 1;
        StartCoroutine(FadeTo(startPos, 4, 0));
    }

    public void LoseMinigame(int index)
    {
        if (fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(startPos, 0, 0));

            switch (index)
            {
                //Desligar Biomass
                case 1:
                    for (int i = 0; i < biomassMinigame.Length; i++)
                    {
                        biomassMinigame[i].SetActive(false);
                    }
                    Timer.Instance.ResetTimer();
                    break;
                
                //Desligar Hidric
                case 2:
                    for (int i = 0; i < hidricMinigame.Length; i++)
                    {
                        hidricMinigame[i].SetActive(false);
                    }                   
                    break;
                
                //Desligar Eolic
                case 3:
                    for (int i = 0; i < eolicMinigame.Length; i++)
                    {
                        eolicMinigame[i].SetActive(false);
                    }  
                    break;
            }
        }
    }
    
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
            for (int i = 0; i < biomassMinigame.Length; i++)
            {
                biomassMinigame[i].SetActive(false);
            }        
        }
        else return;
    }
    public void HidricMinigame(bool isStarting)
    {
        if (isStarting && fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(hidricPos, 2, 0));
        }
        else if (!isStarting && fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(startPos, 0, 2));
            for (int i = 0; i < hidricMinigame.Length; i++)
            {
                hidricMinigame[i].SetActive(false);
            }
        }
        else return;
    }
    public void EolicMinigame(bool isStarting)
    {
        if (isStarting && fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(eolicPos, 3, 0));
        }
        else if (!isStarting && fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(FadeTo(startPos, 0, 3));
            for (int i = 0; i < eolicMinigame.Length; i++)
            {
                eolicMinigame[i].SetActive(false);
            }
        }
        else return;
    }
    

    IEnumerator FadeTo(Vector2 position, int index, int minigameCompleted)
    {
        GameManager.Instance.InputManager.DisableMovement();
        yield return new WaitForSeconds(1);
        
        fade.DOFade(1, fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
        
        cam.ForceCameraPosition(position, Quaternion.identity);
        GameManager.Instance.uiManager.TopUI(false);
        player.transform.position = position;
        
        fade.DOFade(0, fadeDuration * 2);
        yield return new WaitForSeconds(fadeDuration);

        switch (index)
        {
            //Voltar para Fazenda
            case 0:
                FarmUpdate(minigameCompleted);
                GameManager.Instance.soundManager.PlayBGCLip(false, GameManager.Instance.soundManager.backgroundMinigame);
                GameManager.Instance.soundManager.PlayBGCLip(true, GameManager.Instance.soundManager.backgroundGame);
                break;
            
            //Ir para Biomass
            case 1:
                GameManager.Instance.uiManager.CallTutorial(1, biomassTutorial, biomassTutorialDuration);
                break;

            //Ir para Hidrc
            case 2:
                GameManager.Instance.uiManager.CallTutorial(2, hidricTutorial, hidricTutorialDuration);
                break;
            
            //Ir para Eolic
            case 3:
                GameManager.Instance.uiManager.CallTutorial(3, eolicTutorial, eolicTutorialDuration);
                break;
            
            //Inicio do Game
            case 4:
                GameManager.Instance.uiManager.CallTutorial(4, initialTutorial, InitialTutorialDuration);
                break;
            
            default:
                break;
        }
        
        fadeFinished = true;
    }

    public void StartBiomass()
    {
        GameManager.Instance.InputManager.EnableMovement();
        
        //Liga GameObjects com scripts
        for (int i = 0; i < biomassMinigame.Length; i++)
        {
            biomassMinigame[i].SetActive(true);
        }
        
        player.GetComponent<PlayerControl>().speed = 11;
        cam.Follow = null;
        cam.LookAt = null;
    }

    public void StartHidric()
    {
        
        GameManager.Instance.hidricGenerator.CheckAllPipes();
        GameManager.Instance.InputManager.EnableMovement();

        for (int i = 0; i < hidricMinigame.Length; i++)
        {
            hidricMinigame[i].SetActive(true);
        }

        cam.Follow = null;
        cam.LookAt = null;
    }

    public void StartEolic()
    {
        GameManager.Instance.InputManager.EnableMovement();

        for (int i = 0; i < eolicMinigame.Length; i++)
        {
            eolicMinigame[i].SetActive(true);
        }

        cam.Follow = null;
        cam.LookAt = null;
    }

    void FarmUpdate(int index)
    {
        switch (index)
        {
            //Lose Minigame
            case 0:
                GameManager.Instance.uiManager.TopUI(true);
                break;
            
            //Biomass Completed
            case 1:
                biomassFinished = true;
                GameManager.Instance.uiManager.TopUI(true);
                biomass.GetComponent<Interactable>().isComplete = true;
                biomass.GetComponent<Generator>().enabled = true;
                break;
            
            //Hidric Completed
            case 2:
                hidricFinished = true;
                GameManager.Instance.uiManager.TopUI(true);
                hidric.GetComponent<Interactable>().isComplete = true;
                hidric.GetComponent<Generator>().enabled = true;
                break;
            
            //Eolic Completed
            case 3:
                eolicFinished = true;
                GameManager.Instance.uiManager.TopUI(true);
                eolic.GetComponent<Interactable>().isComplete = true;
                eolic.GetComponent<Generator>().enabled = true;
                break;
                
            default:
                break;
        }
        
        GameManager.Instance.InputManager.EnableMovement();
        player.GetComponent<PlayerControl>().speed = 8;
        cam.Follow = player.transform;
        cam.LookAt = player.transform;
        if(biomassFinished && hidricFinished && eolicFinished) StartCoroutine(EndScreen());
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.InputManager.DisableMovement();
        GameManager.Instance.uiManager.CallTutorial(0,"Obrigado por Jogar!", 2);
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0;
    }
}

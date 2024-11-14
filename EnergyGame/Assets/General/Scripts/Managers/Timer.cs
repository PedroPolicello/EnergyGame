using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float totalTime = 120;
    private float time;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        time += Time.deltaTime;
        float remainingTime = totalTime - time;


        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        string minutesString = minutes.ToString("D2");
        string secondsString = seconds.ToString("D2");

        timerText.text = ($"{minutesString}:{secondsString}");

        if (remainingTime <= 0 && GameManager.Instance.biomassGenerator.currentEnergy > 0)
        {
            timerText.text = "00:00";
            GameManager.Instance.minigameController.BiomassMinigame(false);
        }

    }

    public void ResetTimer()
    {
        time = 0;
    }

}
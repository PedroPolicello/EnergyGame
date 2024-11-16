using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay Info")]
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private Image iconImage;
    [SerializeField] private int countdown;
    [SerializeField] private TextMeshProUGUI countdownText;

    [Header("Energy/Money Info")] 
    public int energy;
    public int money;
    [SerializeField] private GameObject topUI;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Biomass Info")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Tutorial Info")] 
    [SerializeField] private GameObject tutorialBox;
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private float duration;
    
    private void Awake()
    {
        moneyText.text = $"Money: {money}";
        energyText.text = $"Energy: {energy}";
        tutorialBox.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void Textbox(bool isVisible, string text)
    {
        if (isVisible)
        {
            textbox.SetActive(true);
            UIText.text = text;
        }
        else
        {
            textbox.SetActive(false);
            UIText.text = text;
        }
    }
    
    public void Icon(bool isVisible, Sprite sprite)
    {
        if (isVisible)
        {
            iconImage.sprite = sprite;
            iconImage.gameObject.SetActive(true);
        }
        else
        {
            iconImage.sprite = sprite;
            iconImage.gameObject.SetActive(false);
        }
    }

    public void TopUI(bool isVisible)
    {
        if(isVisible) topUI.SetActive(true);
        else topUI.SetActive(false);
    }

    public void CallTutorial(int index, string tutorial)
    {
        StartCoroutine(ShowTutorial(index, tutorial));
    }
    
    IEnumerator ShowTutorial(int index, string text)
    {
        tutorialText.text = text;
        tutorialBox.GetComponent<CanvasGroup>().DOFade(1, 1);
        yield return new WaitForSeconds(duration);
        tutorialBox.GetComponent<CanvasGroup>().DOFade(0, 1);

        switch (index)
        {
            //Biomass
            case 1:
                CallCountdown(1);
                break;
            
            //Hidric
            case 2:
                GameManager.Instance.minigameController.StartHidric();
                break;
            
            //Eolic
            case 3:
                CallCountdown(2);
                break;
            
            default:
                break;
        }
    }

    #region Money

    public void AddMoney(int value)
    {
        money += value;
        moneyText.text = $"Money: {money}";
    }
    public void RemoveMoney(int value)
    {
        money -= value;
        moneyText.text = $"Money: {money}";
    }
    
    #endregion
    #region Energy

    public void AddEnergy(int value)
    {
        energy += value;
        energyText.text = $"Energy: {energy}";
    }
    public void RemoveEnergy(int value)
    {
        energy -= value;
        energyText.text = $"Energy: {energy}";
    }
    
    #endregion
    #region Countdown

    public void CallCountdown(int index) => StartCoroutine(Countdown(index));
    IEnumerator Countdown(int index)
    {
        countdownText.gameObject.SetActive(true);
        for (int i = countdown; i > -1; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        switch (index)
        {
            case 1:
                GameManager.Instance.minigameController.StartBiomass();
                break;
            
            case 2:
                GameManager.Instance.minigameController.StartEolic();
                break;
        }
        countdownText.gameObject.SetActive(false);
    }

    #endregion
    #region BiomassUI
    
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = $"Score: {score}";
    }
    public void RemoveScore(int value)
    {
        score -= value;
        scoreText.text = $"Score: {score}";
    }
    
    #endregion
}

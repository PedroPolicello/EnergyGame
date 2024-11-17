using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text Info")]
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private GameObject feedbackBox;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private Image iconImage;

    [Header("CountDown Info")] 
    [SerializeField] private int countdown;
    [SerializeField] private TextMeshProUGUI countdownText;

    [Header("Energy/Money Info")] 
    public int energy;
    public int money;
    [SerializeField] private GameObject topUI;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Generators Info")]
    [SerializeField] private GameObject generatorsList;
    public TextMeshProUGUI hidricText;
    public TextMeshProUGUI eolicText;
    
    [Header("Biomass Minigame Info")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Tutorial Info")] 
    [SerializeField] private GameObject tutorialBox;
    [SerializeField] private TextMeshProUGUI tutorialText;
    
    private void Awake()
    {
        moneyText.text = $"Money: {money}";
        energyText.text = $"Energy: {energy}";
        tutorialBox.SetActive(true);
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
    
    public void Feedbackbox(bool isVisible, string text)
    {
        if (isVisible)
        {
            feedbackBox.SetActive(true);
            feedbackText.text = text;
        }
        else
        {
            feedbackBox.SetActive(false);
            feedbackText.text = text;
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
    
    public void GeneratorsToBuy(bool isVisible)
    {
        if (isVisible)
        {
            hidricText.text = $"Hídrico: {GameManager.Instance.vendorManager.hidricPrice.ToString()}";
            eolicText.text = $"Éolico: {GameManager.Instance.vendorManager.eolicPrice.ToString()}";
            generatorsList.SetActive(true);
        }
        else {generatorsList.SetActive(false);}
    }

    public void CallTutorial(int index, string tutorial, float duration)
    {
        StartCoroutine(ShowTutorial(index, tutorial, duration));
    }
    
    IEnumerator ShowTutorial(int index, string text, float duration)
    {
        tutorialText.text = text;
        tutorialBox.GetComponent<CanvasGroup>().DOFade(1, 1);
        yield return new WaitForSeconds(duration);
        tutorialBox.GetComponent<CanvasGroup>().DOFade(0, 1);
        yield return new WaitForSeconds(1);

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
            
            //Start Game
            case 4:
                GameManager.Instance.InputManager.EnableMovement();
                GameManager.Instance.uiManager.TopUI(true);
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

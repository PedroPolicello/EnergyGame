using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorManager : MonoBehaviour
{
    [SerializeField] private int moneyPerEnergy;

    public int hidricPrice;
    public int eolicPrice;

    [SerializeField] [TextArea(2,3)] private string[] feedbackText;
    [SerializeField] private int duration;
    
    private int generatorIndex;

    private void Awake()
    {
        generatorIndex = 0;
    }

    public void SellEnergy()
    {
        if (GameManager.Instance.uiManager.energy <= 0)
        {
            //Sem Energia
            StartCoroutine(Feedback(feedbackText[0]));
        }
        else
        {
            GameManager.Instance.uiManager.AddMoney(GameManager.Instance.uiManager.energy * moneyPerEnergy);
            GameManager.Instance.uiManager.RemoveEnergy(GameManager.Instance.uiManager.energy);
        }
    }

    public void BuyNextMinigame()
    {
        generatorIndex++;
        switch (generatorIndex)
        {
            case 1:
                if (GameManager.Instance.uiManager.money < hidricPrice)
                {
                    //Sem Dinheiro
                    generatorIndex--;
                    StartCoroutine(Feedback(feedbackText[1]));
                    return;
                }
                else
                {
                    GameManager.Instance.uiManager.hidricText.gameObject.SetActive(false);
                    GameManager.Instance.uiManager.RemoveMoney(hidricPrice);
                    GameManager.Instance.minigameController.hidric.SetActive(true);
                }
                break;
            
            case 2:
                if (GameManager.Instance.uiManager.money < eolicPrice)
                {
                    //Sem Dinheiro
                    generatorIndex--;
                    StartCoroutine(Feedback(feedbackText[1]));
                    return;
                }
                else
                {
                    GameManager.Instance.uiManager.eolicText.gameObject.SetActive(false);
                    GameManager.Instance.uiManager.RemoveMoney(eolicPrice);
                    GameManager.Instance.minigameController.eolic.SetActive(true);
                }
                break;
            
            default:
                //Sem Dinheiro
                generatorIndex--;
                StartCoroutine(Feedback(feedbackText[1]));
                break;
        }
    }

    IEnumerator Feedback(string text)
    {
        GameManager.Instance.uiManager.Feedbackbox(true, text);
        yield return new WaitForSeconds(duration);
        GameManager.Instance.uiManager.Feedbackbox(false, text);
    }

}

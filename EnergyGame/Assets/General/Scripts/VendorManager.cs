using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorManager : MonoBehaviour
{
    [SerializeField] private int moneyPerEnergy;

    [SerializeField] private int hidricPrice;
    [SerializeField] private int eolicPrice;

    private int generatorIndex;

    private void Awake()
    {
        generatorIndex = 0;
    }

    public void SellEnergy()
    {
        if (GameManager.Instance.uiManager.energy <= 0)
        {
            Debug.LogError("Not enough energy");
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
                    Debug.LogError("Not enough money");
                    generatorIndex--;
                    return;
                }
                else
                {
                    GameManager.Instance.uiManager.RemoveMoney(hidricPrice);
                    GameManager.Instance.minigameController.hidric.SetActive(true);
                }
                break;
            
            case 2:
                if (GameManager.Instance.uiManager.money < eolicPrice)
                {
                    Debug.LogError("Not enough money");
                    generatorIndex--;
                    return;
                }
                else
                {
                    GameManager.Instance.uiManager.RemoveMoney(eolicPrice);
                    GameManager.Instance.minigameController.eolic.SetActive(true);
                }
                break;
            
            default:
                Debug.LogError("Not enough money");
                break;
        }
    }

}

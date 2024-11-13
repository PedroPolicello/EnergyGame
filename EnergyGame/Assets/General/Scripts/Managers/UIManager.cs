using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay Info")]
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private Image iconImage;

    [Header("Biomass Info")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int countdown;
    [SerializeField] private TextMeshProUGUI countdownText;

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

    public void CallCountdown() => StartCoroutine(Countdown());
    IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true);
        for (int i = countdown; i > -1; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        
        GameManager.Instance.minigameController.StartBiomass();
        countdownText.gameObject.SetActive(false);
    }

    #region BiomassUI

    public void AddScore(int value)
    {
        score += value;
        UpdateUIScore();
    }

    public void RemoveScore(int value)
    {
        score -= value;
        UpdateUIScore();
    }


    void UpdateUIScore()
    {
        scoreText.text = $"Score: {score}";
    }
    
    

    #endregion
}

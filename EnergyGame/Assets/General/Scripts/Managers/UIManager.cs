using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay Info")]
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private Image iconImage;

    [Header("Score Info")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

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
}

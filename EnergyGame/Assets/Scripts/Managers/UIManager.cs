using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI textUI;

    public void EnableTextbox(string text)
    {
        textbox.SetActive(true);
        textUI.text = text;
    }

    public void DisableTextbox(string text)
    {
        textbox.SetActive(false);
        textUI.text = text;
    }
}

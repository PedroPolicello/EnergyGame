using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public InteractType interactType;
    public bool isComplete;
    
    [Header("TextBox")]
    [SerializeField] private bool useTextBox;
    [SerializeField] [TextArea(2, 5)] private string[] interactText;

    [Header("InteractIcon")]
    [SerializeField] Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.InputManager.SetEnum(interactType);
            //print(GameManager.Instance.InputManager.principalInteractType);

            if (useTextBox && !isComplete)
            {
                GameManager.Instance.uiManager.Textbox(true, interactText[0]);
            }
            else if (useTextBox && isComplete)
            {
                GameManager.Instance.uiManager.Textbox(true, interactText[1]);
            }
            else if(!isComplete)
            {
                GameManager.Instance.uiManager.Icon(true, icon);
            }
            else return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.InputManager.SetEnum(InteractType.None);

            if (useTextBox) GameManager.Instance.uiManager.Textbox(false, "");
            else GameManager.Instance.uiManager.Icon(false, null);
        }
    }
}
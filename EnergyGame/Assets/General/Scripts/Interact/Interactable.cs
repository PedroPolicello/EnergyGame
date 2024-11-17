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

            if (interactType == InteractType.Buy)
            {
                GameManager.Instance.uiManager.GeneratorsToBuy(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.InputManager.SetEnum(InteractType.None);

            if (useTextBox) GameManager.Instance.uiManager.Textbox(false, "");
            else GameManager.Instance.uiManager.Icon(false, null);
            
            if (interactType == InteractType.Buy)
            {
                GameManager.Instance.uiManager.GeneratorsToBuy(false);
            }
        }
    }
}
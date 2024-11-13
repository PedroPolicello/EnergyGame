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
    [SerializeField] [TextArea(3, 8)] private string interactText;
    [SerializeField] [TextArea(3, 8)] private string finishedInteractText;

    [Header("InteractIcon")]
    [SerializeField] Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (useTextBox && !isComplete)
            {
                GameManager.Instance.interactEnum.SetEnum(interactType);
                GameManager.Instance.uiManager.Textbox(true, interactText);
            }
            else if (useTextBox && isComplete)
            {
                GameManager.Instance.uiManager.Textbox(true, finishedInteractText);
            }
            else if(!isComplete)
            {
                GameManager.Instance.interactEnum.SetEnum(interactType);
                GameManager.Instance.uiManager.Icon(true, icon);
            }
            else return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (useTextBox) GameManager.Instance.uiManager.Textbox(false, "");
            else GameManager.Instance.uiManager.Icon(false, null);
        }
    }
}
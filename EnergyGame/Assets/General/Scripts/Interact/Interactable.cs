using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public InteractType interactType;

    [Header("TextBox")]
    [SerializeField] private bool useTextBox;
    [SerializeField] [TextArea(3, 8)] private string interactText;

    [Header("InteractIcon")]
    [SerializeField] Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.interactable.SetEnum(interactType);

            if (useTextBox) GameManager.Instance.uiManager.Textbox(true, interactText);
            else GameManager.Instance.uiManager.Icon(true, icon);
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
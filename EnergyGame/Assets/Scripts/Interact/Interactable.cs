using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public InteractType interactType;

    [SerializeField] [TextArea(3, 8)] private string interactText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.interactable.SetEnum(interactType);
            GameManager.Instance.uiManager.EnableTextbox(interactText);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.uiManager.DisableTextbox("");
        }
    }
}
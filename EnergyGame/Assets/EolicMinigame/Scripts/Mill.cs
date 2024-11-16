using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    [SerializeField] private int millNumber;
    private Animator animator;
    private bool playerColide;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerColide)
        {
            PlayAnim();
        }
    }


    public void PlayAnim()
    {
        animator.SetTrigger("Rotate");
        GameManager.Instance.eolicGenerator.AddPlayerInput(millNumber);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerColide = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerColide = false;
    }
}

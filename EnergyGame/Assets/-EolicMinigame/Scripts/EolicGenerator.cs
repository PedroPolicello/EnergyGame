using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EolicGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] millsToCopy;
    [SerializeField] private GameObject[] millsToInteract;
    [SerializeField] private int[] millsPerSequence;

    public List<int> sequence = new List<int>();
    public List<int> playerInput = new List<int>();
    
    private int millSelected;
    private int index = 1;
    private int checkIndex;
    
    private void OnEnable()
    {
        ResetMinigame();
    }

    void ResetMinigame()
    {
        StartCoroutine(PlayMill(millsPerSequence[0]));
    }

    IEnumerator PlayMill(int millsInSequence)
    {
        yield return new WaitForSeconds(2);
        
        for (int i = 0; i < millsInSequence; i++)
        {
            millSelected = Random.Range(0, millsToCopy.Length);
            sequence.Add(millSelected);
            millsToCopy[millSelected].GetComponent<Animator>().SetTrigger("Rotate");
            yield return new WaitForSeconds(1.5f);
        }
        
        yield return new WaitForSeconds(1);
        GameManager.Instance.InputManager.EnableInteract();
    }

    public void AddPlayerInput(int millPlayed)
    {
        playerInput.Add(millPlayed);
        CheckPlayerInput();
    }

    void CheckPlayerInput()
    {
        if (sequence[checkIndex] == playerInput[checkIndex])
        {
            checkIndex++;
            if (sequence.Count == playerInput.Count)
            {
                print("Acertou");
                //Play Sound
                NewSequence();
                GameManager.Instance.InputManager.DisableInteract();
            }
        }
        else
        {
            print("Errou");
            //Play Sound
            index = 0;
            checkIndex = 0;
            sequence.Clear();
            playerInput.Clear();
            ResetMinigame();
        }
    }

    void NewSequence()
    {
        if (index >= millsPerSequence.Length)
        {
            GameManager.Instance.minigameController.EolicMinigame(false);
            index = 0;
            checkIndex = 0;
            sequence.Clear();
            playerInput.Clear();
            return;
        }
        else
        {
            index++;
            checkIndex = 0;
            sequence.Clear();
            playerInput.Clear();
            StartCoroutine(PlayMill(index));
        }
    }

}

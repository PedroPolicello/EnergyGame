using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidricGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] corretPipes;
    [SerializeField] private bool[] isComplete;
    public int correctPipesCount;

    public void CheckAllPipes()
    {
        for (int i = 0; i < corretPipes.Length; i++)
        {
            if (corretPipes[i].GetComponent<Pipe>().isComplete)
            {
                isComplete[i] = true;
                EndMinigame();
            }
            else
            {
                isComplete[i] = false;
            }
        }
    }

    void EndMinigame()
    {
        if (correctPipesCount == corretPipes.Length)
        {
            GameManager.Instance.minigameController.HidricMinigame(false);
            correctPipesCount = 0;
        }
    }
}

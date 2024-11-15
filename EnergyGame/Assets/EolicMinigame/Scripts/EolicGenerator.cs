using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EolicGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] millsToCopy;
    [SerializeField] private int[] millsPerSequence;

    public List<int> sequence = new List<int>();
    private int millSelected;
    private int index = 1;
    private void OnEnable()
    {
        StartCoroutine(PlayMill(millsPerSequence[0]));
    }

    private void Update()
    {
        
    }
    

    IEnumerator PlayMill(int millsInSequence)
    {
        print($"Sequencia: {index}");
        for (int i = 0; i < millsInSequence; i++)
        {
            millSelected = Random.Range(0, millsToCopy.Length);
            sequence.Add(millSelected);
            millsToCopy[millSelected].GetComponent<Animator>().SetTrigger("Rotate");
            yield return new WaitForSeconds(1.5f);
        }
        
        yield return new WaitForSeconds(2);
        NewSequence();
    }

    void CheckPlayerInput()
    {
        
    }

    void NewSequence()
    {
        if (index >= millsPerSequence.Length)
        {
            print("Gerador Desbloqueado");
            index = 0;
            return;
        }
        else
        {
            index++;
            sequence.Clear();
            StartCoroutine(PlayMill(index));
        }
    }

}

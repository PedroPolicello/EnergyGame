using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Generator : MonoBehaviour
{
    [SerializeField] private int energyToGenerate;
    [SerializeField] private float timeToWait;
    
    private void OnEnable()
    {
       StartCoroutine(StartGenerate());
    }

    IEnumerator StartGenerate()
    {
        for (int i = 0; true; i++)
        {
            yield return new WaitForSeconds(timeToWait);
            GameManager.Instance.uiManager.AddEnergy(energyToGenerate);
        }
    }
    
}

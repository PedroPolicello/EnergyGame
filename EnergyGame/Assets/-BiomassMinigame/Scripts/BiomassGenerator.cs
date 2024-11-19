using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BiomassGenerator : MonoBehaviour
{
    [Header("Biomass Info")]
    [SerializeField] private Slider energyBar;
    [SerializeField] private float time;
    [SerializeField] private int maxEnergy;
    public int currentEnergy;

    [Header("Sound Info")]
    [SerializeField] private float volume;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    private void OnEnable()
    {
        currentEnergy = maxEnergy;
        energyBar.maxValue = currentEnergy;
        energyBar.value = currentEnergy;
        PlaySound();
    }

    private void Start()
    {
        StartCoroutine(EnergyDrop());
    }

    private void Update()
    {
        if(currentEnergy > maxEnergy) currentEnergy = maxEnergy;
        if (currentEnergy < 0)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator EnergyDrop()
    {
        for (int i = 0; true; i++)
        {
            currentEnergy--;
            energyBar.value = currentEnergy;
            if (currentEnergy < 0)
            {
                Debug.LogError("You Lose");
                GameManager.Instance.minigameController.LoseMinigame(1);
            }
            yield return new WaitForSeconds(time);
        }
    }
    

    public void AddEnergy(int amount)
    {
        currentEnergy += amount;
        GameManager.Instance.uiManager.AddScore(amount);
    }

    public void RemoveEnergy(int amount)
    {
        currentEnergy -= amount;
        GameManager.Instance.uiManager.RemoveScore(amount);
    }

    void PlaySound()
    {
        audioSource.loop = true;
        audioSource.Play();
    }
}

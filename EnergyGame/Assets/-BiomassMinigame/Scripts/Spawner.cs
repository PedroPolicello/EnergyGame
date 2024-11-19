using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Vector2 minSpawnPos;
    [SerializeField] private Vector2 maxSpawnPos;
    [SerializeField] private float fuelSpawnTime;
    [SerializeField] private float trashSpawnTime;
    private float posX;
    private float posY;
    private Vector2 spawnPos;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] fuelPrefab;
    [SerializeField] private GameObject trashPrefab;

    private void OnEnable()
    {
        GenerateFuelSpawnPos();
        GenerateTrashSpawnPos();
    }

    void GenerateFuelSpawnPos()
    {
        posX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        posY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        spawnPos = new Vector2(posX, posY);
        StartCoroutine(SpawnFuel());
    }

    IEnumerator SpawnFuel()
    {
        yield return new WaitForSeconds(fuelSpawnTime);
        int selectedPrefab = Random.Range(0, fuelPrefab.Length);
        Instantiate(fuelPrefab[selectedPrefab], spawnPos, Quaternion.identity);
        GenerateFuelSpawnPos();
    }

    void GenerateTrashSpawnPos()
    {
        posX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        posY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        spawnPos = new Vector2(posX, posY);
        StartCoroutine(SpawnTrash());
    }

    IEnumerator SpawnTrash()
    {
        yield return new WaitForSeconds(trashSpawnTime);
        Instantiate(trashPrefab, spawnPos, Quaternion.identity);
        GenerateTrashSpawnPos();
    }
}

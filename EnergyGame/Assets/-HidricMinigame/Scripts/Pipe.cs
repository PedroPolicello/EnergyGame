using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Sprite pipeSprite;
    [SerializeField] private int[] possibleRotations;

    [SerializeField] private int[] correctRotation;
    public bool isComplete;

    private SpriteRenderer spriteRenderer;
    private bool playerColide;

    private bool hasAdd;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pipeSprite;
    }

    private void OnEnable()
    {
        RandomizeRotation();
    }

    private void Start()
    {
        CheckRotation();
        GameManager.Instance.hidricGenerator.CheckAllPipes();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerColide)
        {
            RotatePipe();
            GameManager.Instance.hidricGenerator.CheckAllPipes();
        }

    }

    void RandomizeRotation()
    {
        int randomRotation = Random.Range(0, possibleRotations.Length);
        transform.rotation = Quaternion.AngleAxis(possibleRotations[randomRotation], Vector3.forward);
    }

    public void RotatePipe()
    {
        transform.Rotate(0, 0, 90);
        GameManager.Instance.soundManager.PlaySFXClip(GameManager.Instance.soundManager.rotatePipes);
        CheckRotation();
    }

    void CheckRotation()
    {
        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (Math.Abs(transform.eulerAngles.z - correctRotation[i]) < .5f)
            {
                isComplete = true;
                if (!hasAdd)
                {
                    GameManager.Instance.hidricGenerator.correctPipesCount++;
                    hasAdd = true;
                }

                return;
            }
            else
            {
                isComplete = false;
                if (hasAdd)
                {
                    GameManager.Instance.hidricGenerator.correctPipesCount--;
                    hasAdd = false;
                }
            }
        }
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
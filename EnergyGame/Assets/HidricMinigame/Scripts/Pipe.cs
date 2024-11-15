using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Sprite pipeSprite;
    [SerializeField] private int[] possibleRotations;

    [SerializeField] private int[] correctRotation;
    public bool isComplete;

    private SpriteRenderer spriteRenderer;
    private bool playerColide;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pipeSprite;
    }

    private void OnEnable()
    {
        RandomizeRotation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerColide)
        {
            RotatePipe();
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
        CheckRotation();
    }

    void CheckRotation()
    {
        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (transform.eulerAngles.z == correctRotation[i])
            {
                isComplete = true;
                return;
            }
            else isComplete = false;
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

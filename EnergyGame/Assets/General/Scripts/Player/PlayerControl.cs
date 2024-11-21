using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Info")]
    public float speed;

    private SpriteRenderer spriteRenderer;
    
    [Header("Sound Info")] 
    [SerializeField] private AudioClip trash;
    [SerializeField] private AudioClip bio;
    private AudioSource audioSource;

    [Header("Biomass Info")]
    [SerializeField] private int amountForFuel;
    [SerializeField] private int fuelCollected;
    [HideInInspector] public int fuelAmount;

    private void Awake()
    {
        transform.position = new Vector3(0, 0.9f, 0);
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 moveDirection = new Vector2(InputManager.Instance.Move.x, InputManager.Instance.Move.y);
        transform.Translate(moveDirection * (speed * Time.deltaTime));

        if (moveDirection.x > 0)
            spriteRenderer.flipX = false;
        else if(moveDirection.x < 0)
            spriteRenderer.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Biomass Minigame

        if (collision.CompareTag("Fuel"))
        {
            audioSource.PlayOneShot(bio);
            fuelCollected++;
            fuelAmount = amountForFuel * fuelCollected;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Trash"))
        {
            GameManager.Instance.biomassGenerator.RemoveEnergy(amountForFuel);
            audioSource.PlayOneShot(trash);
            Destroy(collision.gameObject);
        }
        
        #endregion
    }
    
    public void ResetFuel()
    {
        fuelCollected = 0;
        fuelAmount = 0;
    }
}

using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Info")]
    public float speed;

    [Header("Biomass Info")]
    [SerializeField] private int amountForFuel;
    [SerializeField] private int fuelCollected;
    [HideInInspector] public int fuelAmount;

    private void Awake()
    {
        transform.position = new Vector3(0, 0.9f, 0);
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 moveDirection = new Vector2(InputManager.Instance.Move.x, InputManager.Instance.Move.y);
        transform.Translate(moveDirection * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            //InputManager.Instance.near = GameManager.Instance.interactEnum.principalInteractType;
        }

        #region Biomass Minigame

        if (collision.CompareTag("Fuel"))
        {
            fuelCollected++;
            fuelAmount = amountForFuel * fuelCollected;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Trash"))
        {
            GameManager.Instance.biomassGenerator.RemoveEnergy(amountForFuel);
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

using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private float speed;

    [Header("Bag Info")]
    [SerializeField] private int amountForFuel;
    [SerializeField] private int fuelCollected;
    [HideInInspector] public int fuelAmount;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 moveDirection = new Vector2(InputManager.Instance.Move.x, InputManager.Instance.Move.y);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable")) InputManager.Instance.near = GameManager.Instance.interactable.interactType;

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
    }
     public void ResetFuel()
    {
        fuelCollected = 0;
        fuelAmount = 0;
    }
}

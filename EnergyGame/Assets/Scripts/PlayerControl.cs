using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;

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
        InputManager.Instance.near = GameManager.Instance.interactable.interactType;
    }
}

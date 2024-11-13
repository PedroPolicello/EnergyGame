using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region serialize
    [SerializeField] private float speed;
    #endregion

    #region private
    private Vector2 _movement;
    #endregion

    #region public
    public Vector2 movement
    {
        get { return _movement;}
        set { _movement = value; }

    }

    #endregion

    #region components
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    #endregion

    #region monobehaviour


    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

       
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        OnMove();
    }
    #endregion

    #region custom
    void Move()
    {
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(_movement.x !=0)
        transform.localScale = new Vector2(_movement.x, 1);

    }

    void OnMove()
    {
        rigidBody2D.velocity = _movement.normalized * speed;
    }
    #endregion
}

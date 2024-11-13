using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator animator;
    private PlayerManager playerManager;

    void Awake()
    {
        animator = GetComponent<Animator>(); 
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (playerManager.movement.sqrMagnitude == 0)
        {
            animator.SetInteger("Animation", 0);
        }
        else
        {
          animator.SetInteger("Animation", 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerSwingAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        
    }

    private void OnAttack(InputValue input)
    {
        if (animator != null && playerMovement.movementVector == Vector3.zero && !animator.GetCurrentAnimatorStateInfo(0).IsName(""))
        {
            animator.SetTrigger("IsSwinging");
        }
    }
}

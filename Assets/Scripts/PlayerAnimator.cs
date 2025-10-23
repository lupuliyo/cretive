using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moveDir.x != 0 || playerMovement.moveDir.y != 0)
        {
            animator.SetBool("Move", true);
        }
        else { animator.SetBool("Move", false); }
        SpriteDirection();
    }
    void fixedUpdate() {

      
    }


    void SpriteDirection()
    { 
        if (playerMovement.moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerMovement.moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}

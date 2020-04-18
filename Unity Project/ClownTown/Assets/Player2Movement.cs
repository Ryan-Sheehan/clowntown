using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    public float runSpeed = 40;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetButtonDown("Jump2"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonDown("Crouch2"))
                crouch = true;
            else if (Input.GetButtonUp("Crouch2"))
                crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

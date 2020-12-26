using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        // These inputs are refering to, in Unity: Edit > Project Settings > Input Manager

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        // Move our character!
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // Time.fixedDeltaTime ensure that we move the same amount, accross all systems!

        jump = false;
    }
}

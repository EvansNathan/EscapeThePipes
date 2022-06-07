using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject startPoint;
    public Animator animator;
    public GameObject playerObj;
    public Canvas controls;
    public bool isDead;
    public float runSpeed;
    public float sprintMultiplier;
    private float multiplier;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool sprint = false;

    public SpriteRenderer sprite;

    public Sprite[] spriteArray;


    private void Awake()
    {
        playerObj.transform.position = startPoint.transform.position;
        multiplier = sprintMultiplier;
        //this.GetComponent<PlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isDead)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;

            }
            if (Input.GetButtonDown("ToggleControls"))
            {
                controls.enabled = !controls.enabled;
            }
            if (Input.GetButtonDown("Sprint"))
            {
                sprint = true;
            }
            else if (Input.GetButtonUp("Sprint"))
            {
                sprint = false;
            }
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }

            if (playerObj.GetComponent<Rigidbody2D>().velocity.y > 5)
            {
                sprite.sprite = spriteArray[1];
                animator.enabled = false;
            }
            else if (playerObj.GetComponent<Rigidbody2D>().velocity.y < -5)
            {
                sprite.sprite = spriteArray[2];
                animator.enabled = false;
            }
            else if (playerObj.GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                sprite.sprite = spriteArray[0];
                animator.enabled = true;
            }
        }
        else
        {
            horizontalMove = 0;
        }
    }


    void FixedUpdate()
    {
        // Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, sprint);
        jump = false;

    }
}


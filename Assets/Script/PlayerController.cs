using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    public float speed = 5f;
    public float jumpSpeed = 10f;

    //Variables for GroundCheck (Stops player from double jumping)
    [SerializeField] private Transform groundCheck;
    private float groundCheckRadius = 0.5f; //Change when player sprite is added
    [SerializeField] public LayerMask groundLayer;
    private bool isTouchingGround;
    public Animator animator;
    SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Left & Right Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
        playerRb.velocity = velocity;


        //Checks if the player is touching the ground 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Uses the W Key & Up Arrow to Jump
        if (isTouchingGround && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            //playerSprite.flipX = true;
        }

        //Animation
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Speed", velocity.sqrMagnitude);
        animator.SetBool("IsJumping", !isTouchingGround);
    }

    void FixedUpdate()
    {
   

        
    }
}


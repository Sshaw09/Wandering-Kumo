using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float horizontalInput;

    //Variables for GroundCheck (Stops player from double jumping)
    public Transform groundCheck;
    private float groundCheckRadius = 0.5f; //Change when player sprite is added
    public LayerMask groundLayer;
    public bool isTouchingGround;

    //Animation Variables
    public Animator animator;
    SpriteRenderer playerSprite;

    //Projectile Variables
    public GameObject projectilePrefab;
    public Transform launchOffset;
    float projectileSpeed = 4.5f;

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
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
        playerRb.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(projectilePrefab, launchOffset.position, launchOffset.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = launchOffset.up * projectileSpeed;
        }

        //Animation
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Speed", velocity.sqrMagnitude);
        animator.SetBool("IsJumping", !isTouchingGround);

        //Methods
        Jump();
    }

    void Jump()
    {
        //Checks if the player is touching the ground 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Uses the W Key & Up Arrow to Jump
        if (isTouchingGround && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            //playerSprite.flipX = true;
        }
    }
    
}


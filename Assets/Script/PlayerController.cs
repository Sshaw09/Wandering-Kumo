using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("*Movement*")] //Overall Movement
    Rigidbody2D playerRb;
    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float horizontalInput;

    [Header("*Ground Check*")] //Variables for GroundCheck (Stops player from double jumping)
    public Transform groundCheck;
    private float groundCheckRadius = 0.5f; //Change when player sprite is added
    public LayerMask groundLayer;
    public bool isTouchingGround;

    [Header("*Animation*")] //Animation Variables
    public Animator animator;
    SpriteRenderer playerSprite;

    [Header("*Projectile*")] //Projectile Variables
    public GameObject projectilePrefab;
    public Transform launchOffset;
    float projectileSpeed = 4.5f;
    [SerializeField] AudioSource projectileSound;

    // Look Direction for projectiles
    Vector2 lookDirection = new Vector2(1, 0);

    [Header("*Level 2*")] //For Level2
    [SerializeField] public static int score2;
    [SerializeField] AudioSource coinSound;
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

        // Set which direction the player is looking
        Vector2 move = new Vector2(horizontalInput, 0);

        if (!Mathf.Approximately(move.x, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.projectileActive)
        {
            Launch(); 
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
        }
    }

    public void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectileObject.GetComponent<Rigidbody2D>().velocity = lookDirection * projectileSpeed;
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 1000);
        projectileSound.Play();
    }

    //For Level 2
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score2++;
            Debug.Log(score2);
            Destroy(collision.gameObject);
            coinSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            SceneManager.LoadScene("4 Level2.5");
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            SceneManager.LoadScene("0 Pre-level");
        }
    }


}
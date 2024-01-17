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
    Vector2 boxCheck = new Vector2(0.6f, 0.15f);
    float castDistance = 1.35f;
    public LayerMask groundLayer;

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

    [Header("*Death")] //For Death Screen
    public GameObject gameOver;

    //Level3
    public static int crystal;
    [SerializeField] AudioSource crystalSound;

    // Start is called before the first frame update
    private void Awake()
    {
        crystal = 0;
    }

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
            StartCoroutine(LaunchMagic());
        }

        //Animation
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Speed", velocity.sqrMagnitude);
        animator.SetBool("IsJumping", !isGrounded());

        

        //Methods
        Jump();

        Physics2D.IgnoreLayerCollision(8, 9);
    }



    void Jump()
    {
        //Uses the W Key & Up Arrow to Jump
        if (isGrounded() && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
        }
    }

    //GroundCheck
    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxCheck, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxCheck);
    }

    public void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
        projectileObject.GetComponent<Rigidbody2D>().velocity = lookDirection * projectileSpeed;
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 1000);
        projectileSound.Play();
    }

    //For Level 3
    IEnumerator LaunchMagic()
    {
        Launch();
        GameManager.projectileActive = false;
        yield return new WaitForSeconds(0.5f);
        GameManager.projectileActive = true;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //For Level 2
        //Crystal
        if (collision.gameObject.CompareTag("Coin"))
        {
            score2++;
            Destroy(collision.gameObject);
            coinSound.Play();
        }

        if (collision.gameObject.CompareTag("Crystal"))
        {
            crystal++;
            Destroy(collision.gameObject);
            crystalSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            SceneManager.LoadScene("4 Level2.5");
            score2 = 0;
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            gameOver.SetActive(true);
        }
    }


}
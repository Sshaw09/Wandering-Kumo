using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public int direction = 1;
    public float timer = 3;
    public float changeTime = 3;
    [SerializeField] Transform posToGo;
    Rigidbody2D rb;
    Animator animator;
    public Transform offset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        Vector2 position = transform.position;
        if (changeTime < 0)
        {
            direction = -direction;
            changeTime = timer;
        }
        position.x = position.x + Time.deltaTime * speed * direction;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Projectile"))
        {
            Destroy(gameObject);
        }

    }
}

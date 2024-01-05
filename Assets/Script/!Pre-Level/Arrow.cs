using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    public float speed = 5;
    int direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Makes the arrow move left on the x-axis
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        transform.position = position;
    }

    //Arrows detroys itself when it hits the dirt titles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dirt"))
        {
            Destroy(gameObject);
        }
    }
}

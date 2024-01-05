using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
    public float speed = 5;
    int direction = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //Makes the arrow move down on the y-axis
    void Update()
    {
        Vector2 position = transform.position;
        position.y = position.y + Time.deltaTime * speed * direction;
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


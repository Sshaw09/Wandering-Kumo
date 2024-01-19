using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 5.5f;
    public float stoppingDistance = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > stoppingDistance)
        {
            Vector2 direction = player.transform.position - transform.position;

            direction.Normalize();

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);

        }

    }
}

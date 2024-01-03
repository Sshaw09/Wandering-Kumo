using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject text;
    private bool arrowCheck = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        if (arrowCheck == false)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
            arrowCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }

}

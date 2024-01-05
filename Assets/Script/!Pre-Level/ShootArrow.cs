using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject text;
    private bool arrowCheck = false;
    public AudioSource sound;
    public AudioSource arrowShot;

    //Arrow gets shot from a certain position
    //Plays a slight sound
    //Also activates UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        if (arrowCheck == false)
        {
            arrowShot.Play();
            Instantiate(arrow, transform.position, Quaternion.identity);
            sound.Play();
            arrowCheck = true;
        }
    }
    //Deactivates UI
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }

}

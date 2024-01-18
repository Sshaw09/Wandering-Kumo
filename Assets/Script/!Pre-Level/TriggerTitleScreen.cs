using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerTitleScreen : MonoBehaviour
{
    public GameObject dirt;
    public GameObject darkness;
    public ParticleSystem explosion;
    public ParticleSystem explosion1;
    public ParticleSystem explosion2;
    public AudioSource explode;
    public AudioSource noSound;
    public GameObject turnOff;
    public TextMeshProUGUI scoreText;

    //Turns off all UI
    //Makes a big hole in the ground
    //Causes darkess to fill up the screen
    //Plays a lot of explosions
    //Random person screaming No, Alexandria revealing player's name
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreText.text = " ";
        dirt.SetActive(false);
        darkness.SetActive(true);
        explosion.Play();
        explosion1.Play();
        explosion2.Play();
        explode.Play();
        noSound.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelTwo : MonoBehaviour
{
    [SerializeField] ParticleSystem boom = default;
    [SerializeField] AudioSource boomSound;
    private bool boomPlayed = false;

    //When player enters the ruin door, the new scene starts
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene("3 Level2");
    }

    //Plays the explosion and sound when barrier gets destroyed
    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Ruin") && !boomPlayed)
        {
            boom.Play();
            boomSound.Play();
            boomPlayed = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelTwo : MonoBehaviour
{
    [SerializeField] ParticleSystem boom = default;
    [SerializeField] AudioSource boomSound;
    private bool boomPlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene("Level2");
    }

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

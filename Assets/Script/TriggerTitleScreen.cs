using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTitleScreen : MonoBehaviour
{
    public GameObject dirt;
    public GameObject darkness;
    public ParticleSystem explosion;
    public ParticleSystem explosion1;
    public ParticleSystem explosion2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dirt.SetActive(false);
        darkness.SetActive(true);
        explosion.Play();
        explosion1.Play();
        explosion2.Play();
    }
}

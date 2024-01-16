using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 2;
    public Image[] hearts;
    public Sprite fullHealth;
    public Sprite emptyHealth;
    public AudioSource hurtSound;
    public GameObject gameOver;
    private void Awake()
    {
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Health Loop
        foreach (Image img in hearts)
        {
            img.sprite = emptyHealth;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHealth;
        }

        if (health == 0)
        {
            gameOver.SetActive(true);
        }
        else
        {
            GetHurt();
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime3"))
        {
            health--;
            hurtSound.Play();
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            health--;
            hurtSound.Play();
        }

        if (collision.gameObject.CompareTag("BArrow"))
        {
            Destroy(collision.gameObject);
            health--;
            hurtSound.Play();
        }
    }
}

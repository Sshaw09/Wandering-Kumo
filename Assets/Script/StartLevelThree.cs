using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelThree : MonoBehaviour
{
    public GameObject text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerController.score2 >= 10)
        {
            SceneManager.LoadScene("1 TitleScreen");
            Debug.Log("Good");

        }
        else
        {
            text.SetActive(true);
            Debug.Log("bad");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}

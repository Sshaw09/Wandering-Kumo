using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelThree_Five : MonoBehaviour
{
    public GameObject text;
    //If player has 10 coins, they are sent to level 3.5
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerController.score2 >= 10)
        {
            SceneManager.LoadScene("1 TitleScreen");
        }
        else
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelThree_Five : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject text;
    //If player has 10 coins, they are sent to level 3.5
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerController.score2 >= 10)
        {
            StartCoroutine(LoadScene());
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

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("6 Level3.5");
    }
}

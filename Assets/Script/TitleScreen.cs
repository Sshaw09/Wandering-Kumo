using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("2 Level1");
    }

    public void QuiGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}

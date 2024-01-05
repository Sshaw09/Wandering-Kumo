using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    //Allows you to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene("2 Level1");
    }

    //Allows you to quiz game :( 
    public void QuiGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTitleScreen : MonoBehaviour
{
    //Simple, Loads the Titlescreen script
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("1 TitleScreen");
    }


}

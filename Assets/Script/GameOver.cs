using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sceneName;
    public GameObject turnOff;

    public void ClickGameOver()
    {
        SceneManager.LoadScene(sceneName);
        turnOff.SetActive(false);
        Debug.Log("Pressed");
    }
}

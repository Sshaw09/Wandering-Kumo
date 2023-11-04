using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
       OpenMenuScreen();
    }

    void OpenMenuScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.gameObject.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        menu.gameObject.SetActive(false);
    }
}

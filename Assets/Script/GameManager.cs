using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenMenuScreen();
        ResumeGame();
    }

    void OpenMenuScreen()
    {
        if (Input.GetKey("escape") )
        {
            menu.gameObject.SetActive(true);
        }
    }

    void ResumeGame()
    {
        menu.gameObject.SetActive(false);
    }
}

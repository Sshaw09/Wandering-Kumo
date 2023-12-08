using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelTwo : MonoBehaviour
{
    [SerializeField] GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("TitleScreen");
        }

        text.SetActive(true);
    }


}

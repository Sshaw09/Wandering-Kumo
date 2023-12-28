using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    [SerializeField] public static bool projectileActive = false;
    public GameObject leftBorder;
    [SerializeField] AudioSource musicSource;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI magicText;
    public GameObject[] menuScreen;
    public ParticleSystem teleport;
    public GameObject ruinMaster;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       OpenMenuScreen();
       scoreText.text = PlayerController.score2.ToString() + "/ 10 Coins";

        if(PlayerController.score2 == 10)
        {
            ruinMaster.SetActive(true);
        }
        else
        {
            ruinMaster.SetActive(false);
        }

        if(PlayerController.score2 >= 10){
            scoreText.text = "Head to the top right";
        }
    }

    void OpenMenuScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.gameObject.SetActive(true);
            DeactivateGameObjects();
        }

        if(projectileActive == true)
        {
            magicText.text = "Space: Use Magic";
        }
    }

    public void ProjectileCheck()
    {
        projectileActive = true;
    }

    public void DestroyBorder()
    {
        Destroy(leftBorder);
    }

    public void QuiGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void DeactivateGameObjects()
    {
        foreach (GameObject go in menuScreen)
        {
            go.SetActive(false);
        }
    }

    public void activateGameObjects()
    {
        foreach (GameObject go in menuScreen)
        {
            go.SetActive(true);
        }
    }

    public void TeleportAnimation()
    {
        teleport.Play();
    }

    public void DestroyRuinMaster()
    {
        PlayerController.score2++;
    }
}


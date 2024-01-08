using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    [SerializeField] public static bool projectileActive = false;
    public GameObject leftBorder;
    [SerializeField] AudioSource musicSource;
    public TextMeshProUGUI magicText;
    public GameObject[] menuScreen;
    public AudioSource teleportSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       OpenMenuScreen();
    }

    //Opens the MenuScreen
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

    //Allows player to use magic (Used in Wizard)
    public void ProjectileCheck()
    {
        projectileActive = true;
    }

    //Allows player to talk to the wizard (Used in Jack)
    public void DestroyBorder()
    {
        Destroy(leftBorder);
    }

    //Allows players to quit the game :( (Used in MenuScreen)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    //Allows certain objects to not be in scene when game is paused (Used in MenuScreen)
    public void DeactivateGameObjects()
    {
        foreach (GameObject go in menuScreen)
        {
            go.SetActive(false);
        }
    }

    //Reactivates obejects in screen
    public void activateGameObjects()
    {
        foreach (GameObject go in menuScreen)
        {
            go.SetActive(true);
        }
    }

    //Detroys end person 
    public void DestroyRuinMaster()
    {
        PlayerController.score2++;
    }

    //Plays the teleport sound (Used by Ruin Master && Shadow)
    public void TPSound()
    {
        teleportSound.Play();
    }

    public void GainCrystal()
    {
        PlayerController.crystal++;
    }
}


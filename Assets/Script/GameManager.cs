using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    [SerializeField] public static bool projectileActive = false;
    public GameObject leftBorder;
    [SerializeField] AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {

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

    public void ProjectileCheck()
    {
        projectileActive = true;
    }

    public void DestroyBorder()
    {
        Destroy(leftBorder);
    }

}

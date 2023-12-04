using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;

public class TestGameManager : MonoBehaviour
{
    public static int arrowER;
    public GameObject arrow;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    bool coinCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (!GameObject.FindGameObjectWithTag("Arrow") && arrowER <= 4)
        {
            Instantiate(arrow, new Vector3(5, -3.5f, 0), transform.rotation);
            arrowER++;
        }

        scoreText.text = arrowER + "/5 arrow dodged";

        if(arrowER == 5 && !coinCheck)
        {
            Instantiate(coin, new Vector3(0, -3.5f, 0), transform.rotation);
            coinCheck = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject coinImage;
    public GameObject ruinMaster;
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {

        //Allows the score to update everytime a ruin is picked up
        scoreText.text = PlayerController.score2.ToString() + "/ 10";

        //Allows someone to show up when you collect 10 coins and despawn after
        if (PlayerController.score2 == 10)
        {
            ruinMaster.SetActive(true);
        }
        else
        {
            ruinMaster.SetActive(false);
        }

        //Lets the player know to head to the top right
        if (PlayerController.score2 >= 10)
        {
            scoreText.text = "Head to the top right";
            coinImage.SetActive(false);
        }
    }
}

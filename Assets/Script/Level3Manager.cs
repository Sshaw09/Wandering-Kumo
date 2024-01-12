using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject score;
    public GameObject text;
    public GameObject clouds;
    public GameObject shadowText;
    public GameObject shadowText2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerController.crystal.ToString();

        if (PlayerController.crystal == 4)
        {
            shadowText.SetActive(false);
            shadowText2.SetActive(true);
        }

        if (PlayerController.crystal == 5)
        {
            score.SetActive(false);
            text.SetActive(true);
            clouds.SetActive(true);
        }

    }
}

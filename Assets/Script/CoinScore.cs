using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    public TextMeshPro scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerController.score2.ToString() + "/ 10 Coins";
    }
}

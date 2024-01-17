using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BossLevelManager : MonoBehaviour
{
    [SerializeField] GameObject shadow;
    public float countdownTime = 10f;
    bool shadowCheck = false;
    private Coroutine ShadowSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Golem.Bosshealth == 0)
        {
            ShadowSpawn = StartCoroutine(CountdownAndSpawnShadow());
        }

        if (shadowCheck)
        {
            StopCoroutine(ShadowSpawn);
            Debug.Log("STOPPED");
        }
    }

    IEnumerator CountdownAndSpawnShadow()
    {
        float timer = countdownTime;

        while (timer > 0)
        {
            Debug.Log("Countdown: " + timer);
            yield return new WaitForSeconds(1f);
            timer--;
        }

        Debug.Log(timer);
        shadow.SetActive(true);
        shadowCheck = true;
    }
}

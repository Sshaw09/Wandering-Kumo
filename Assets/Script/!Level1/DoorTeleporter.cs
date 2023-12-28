using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class DoorTeleporter : MonoBehaviour
{
    public bool playerDoorDetected;
    [SerializeField] Transform posToGo;
    [SerializeField] GameObject text;
    GameObject player;
    [SerializeField] AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        playerDoorDetected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerDoorDetected)
        {
            player.transform.position = posToGo.position;
            playerDoorDetected = false;
            text.SetActive(false);
            doorSound.Play();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")){
            playerDoorDetected = true;
            player = other.gameObject;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            playerDoorDetected = false;
            text.SetActive(false);
        }
    }


}


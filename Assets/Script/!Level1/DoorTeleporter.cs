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
        //Checks if people clicks E && is standing infront of the dorr
        //Teleports them to the other door
        if (Input.GetKeyDown(KeyCode.E) && playerDoorDetected)
        {
            player.transform.position = posToGo.position;
            playerDoorDetected = false;
            text.SetActive(false);
            doorSound.Play();
        }

    }

    //Uses Trigger to detect player && Actives UI
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")){
            playerDoorDetected = true;
            player = other.gameObject;
            text.SetActive(true);
        }
    }
    //Uses Trigger to detect player not sure && Deactives UI
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            playerDoorDetected = false;
            text.SetActive(false);
        }
    }


}


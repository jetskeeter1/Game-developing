using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject pickUpText;
    public GameObject hud;

    // public AudioSource pickUpSound; pag butangan nag sounds

    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        hud.SetActive(true);
        noteUI.SetActive(false);
        pickUpText.SetActive(false);

        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
            //pickUpSound.Play();
            hud.SetActive(false);
        }

        // Add exit functionality when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noteUI.SetActive(false);
            hud.SetActive(true);
        }
    }
}

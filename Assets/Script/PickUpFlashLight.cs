using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashLight : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject FlashOnPlayer;
    public AudioClip pickUpSound;  // Aggiunto il suono quando si raccoglie l'oggetto
    private AudioSource audioSource;  // Riferimento all'AudioSource
    private bool isPickedUp = false;
    private bool isPlayerNear = false;
    private Renderer objectRenderer;  // Riferimento al renderer

    void Start()
    {
        FlashOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();  // Inizializza l'AudioSource
        audioSource.clip = pickUpSound;  // Assegna il suono all'AudioSource
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !isPickedUp)
        {
            PickUp();
        }
        else if (isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        isPickedUp = true;
        objectRenderer.enabled = false;
        FlashOnPlayer.SetActive(true);
        PickUpText.SetActive(false);

        // Riproduci il suono quando l'oggetto viene raccolto
        audioSource.Play();
    }

    private void Drop()
    {
        isPickedUp = false;
        objectRenderer.enabled = true;
        FlashOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
        Debug.Log("Oggetto riposizionato");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            PickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            PickUpText.SetActive(false);
        }
    }
}

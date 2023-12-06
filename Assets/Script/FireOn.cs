using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject proximityText;
    public AudioClip fireSound; // Aggiungi l'audio clip del fuoco
    private bool isVisible = false;
    private bool isPlayerNearby = false;
    private AudioSource audioSource; // Aggiungi l'audio source

    void Start()
    {
        targetObject.SetActive(false);
        proximityText.SetActive(false);

        // Ottieni o aggiungi l'AudioSource all'oggetto corrente
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assegna l'audio clip al componente AudioSource
        audioSource.clip = fireSound;
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.P))
        {
            isVisible = !isVisible;
            targetObject.SetActive(isVisible);

            if (isVisible)
            {
                proximityText.SetActive(false);

                // Riproduci il suono quando il fuoco si accende
                audioSource.Play();
            }
            else
            {
                // Interrompi la riproduzione del suono quando il fuoco viene spento
                audioSource.Stop();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isVisible && other.gameObject.tag == "Player")
        {
            proximityText.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!isVisible && other.gameObject.tag == "Player")
        {
            proximityText.SetActive(false);
            isPlayerNearby = false;
        }
    }
}

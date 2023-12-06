using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBucket : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject proximityText;
    public AudioClip suonoAttivazione; // Suono da riprodurre quando l'oggetto viene acceso/spento
    private bool isVisible = false;
    private bool isPlayerNearby = false;
    private AudioSource audioSource; // Aggiunto per la riproduzione del suono

    void Start()
    {
        targetObject.SetActive(false);
        proximityText.SetActive(false);

        // Inizializza l'AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = suonoAttivazione;
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.B))
        {
            // Inverti la visibilità
            isVisible = !isVisible;

            // Abilita o disabilita l'oggetto target in base alla visibilità
            targetObject.SetActive(isVisible);

            // Riproduci il suono di attivazione/spegnimento
            audioSource.Play();

            // Disabilita il testo di prossimità quando accendi l'oggetto
            if (isVisible)
            {
                proximityText.SetActive(false);
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

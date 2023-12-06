using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject oggettoDaSpostare;
    public GameObject proximityText; 
    public AudioClip suonoApertura; // Aggiunto per il suono di apertura
    public float velocitaSpostamento = 0.05f; // Velocità per spostare di 5 cm
    private bool staSpostando = false;
    private float distanzaPercorsa = 0f;
    public Collider personaggioCollider; // Assegna il Collider del personaggio nell'inspector
    private AudioSource audioSource; // Aggiunto per la riproduzione del suono

    void Start()
    {
        // Nascondi il testo all'inizio
        proximityText.SetActive(false);

        // Inizializza l'AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = suonoApertura;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (IsPlayerNear())
            {
                staSpostando = !staSpostando;

                if (staSpostando)
                {
                    // Riproduci il suono di apertura quando inizi a spostare l'oggetto
                    audioSource.Play();
                }
            }
        }

        if (staSpostando)
        {
            float spostamentoY = Time.deltaTime * velocitaSpostamento;
            oggettoDaSpostare.transform.Translate(0, spostamentoY, 0);
            distanzaPercorsa += Mathf.Abs(spostamentoY);

            if (distanzaPercorsa >= 3f) // 0.05f rappresenta 5 cm
            {
                staSpostando = false;
                proximityText.SetActive(false);
            }
        }
    }

    bool IsPlayerNear()
    {
        if (personaggioCollider != null)
        {
            float distanzaMinima = 1.5f; // Regola questa distanza a seconda di quanto vuoi che il giocatore sia vicino
            return Vector3.Distance(personaggioCollider.transform.position, oggettoDaSpostare.transform.position) < distanzaMinima;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!staSpostando && other.gameObject.tag == "Player")
        {
            // Attiva il testo di prossimità
            proximityText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!staSpostando && other.gameObject.tag == "Player")
        {
            // Disabilita il testo di prossimità
            proximityText.SetActive(false);
        }
    }
}

using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip backgroundMusic; // Aggiungi la tua clip audio nel campo ispettore
    private AudioSource audioSource;
    public Transform playerTransform; // Assegna il transform del giocatore nel campo ispettore
    public float proximityDistance = 5f; // Distanza massima per far partire la musica

    void Start()
    {
        // Inizializza l'AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;

        // Assicurati che l'AudioSource sia impostato per riprodurre in loop
        audioSource.loop = true;

        // Inizia la musica
        audioSource.Play();
        audioSource.Pause(); // Metti in pausa la musica all'inizio
    }

    void Update()
    {
        // Calcola la distanza tra l'oggetto e il giocatore
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Controlla se il giocatore è abbastanza vicino per far partire la musica
        if (distanceToPlayer <= proximityDistance)
        {
            // Riproduci la musica se non è già in riproduzione
            if (!audioSource.isPlaying)
            {
                audioSource.UnPause(); // Riprendi la riproduzione se era in pausa
            }
        }
        else
        {
            // Metti in pausa la musica se il giocatore è abbastanza lontano
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }
}

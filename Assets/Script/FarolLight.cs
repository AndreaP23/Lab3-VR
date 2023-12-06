using UnityEngine;

public class FarolLight : MonoBehaviour
{
    public Light lampioneLight;
    public GameObject Text;
    public AudioClip suonoAccensione; // Suono da riprodurre quando il lampione viene acceso
    private AudioSource audioSource;

    void Start()
    {
        lampioneLight.enabled = false;
        Text.SetActive(false);

        // Inizializza l'AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = suonoAccensione;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Text.SetActive(false);
            ToggleLuce();

            // Riproduci il suono di accensione
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
            EnableLuce();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableLuce();
        }
    }

    void EnableLuce()
    {
        lampioneLight.enabled = true;
    }

    void DisableLuce()
    {
        lampioneLight.enabled = false;
    }

    void ToggleLuce()
    {
        lampioneLight.enabled = !lampioneLight.enabled;
    }
}

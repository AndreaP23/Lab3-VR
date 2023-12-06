using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameObject displayText; // Reference to the text object to display
    public AudioClip audioClip;    // Sound to play

    private AudioSource audioSource;
    private bool isRadioOn = false;

    void Start()
    {
        // Make sure the text object is deactivated at the beginning
        displayText.SetActive(false);

        // Initialize the AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The player is in the collider zone, show the text
            displayText.SetActive(true);

            // Check if the player presses the R key
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Toggle the radio state (on/off)
                isRadioOn = !isRadioOn;

                if (isRadioOn)
                {
                    // If the radio is on, play the sound
                    audioSource.Play();
                }
                else
                {
                    // If the radio is off, stop the sound
                    audioSource.Stop();
                }

                // Hide the text
                displayText.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The player has moved away from the collider zone, hide the text
            displayText.SetActive(false);
        }
    }
}

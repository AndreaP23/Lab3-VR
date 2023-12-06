using UnityEngine;

public class OpenTreasure : MonoBehaviour
{
    public GameObject closedChest; // Modello del forziere chiuso
    public GameObject openChest;   // Modello del forziere aperto
    public GameObject PickUpText;
    public float interactionDistance = 2.0f; // Distanza massima per interagire con il forziere

    private bool isChestOpen = false;
    private Transform player;

    private void Start()
    {
        // Assicurati che i modelli siano assegnati nell'Editor Unity
        if (closedChest == null || openChest == null)
        {
            Debug.LogError("I modelli non sono stati assegnati. Assicurati di assegnare i modelli nell'Editor Unity.");
        }

        // Inizialmente, il forziere dovrebbe essere chiuso e il forziere aperto dovrebbe essere disattivato
        openChest.SetActive(false);
        closedChest.SetActive(true);
        PickUpText.SetActive(false);
    }

    private void Update()
    {
        // Trova il giocatore (potresti farlo in Start() o in un altro modo appropriato)
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        // Calcola la distanza tra il forziere e il giocatore
        float distance = Vector3.Distance(transform.position, player.position);

        // Puoi aprire il forziere solo se sei vicino e premi un pulsante, ad esempio "E"
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && !isChestOpen)
        {
            OpenChest();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isChestOpen)
        {
            PickUpText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenChest();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

    public void OpenChest()
    {
        openChest.SetActive(true);
        closedChest.SetActive(false);
        PickUpText.SetActive(false);
        isChestOpen = true;
    }
}

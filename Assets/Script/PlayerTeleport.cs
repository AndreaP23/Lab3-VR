using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject startObject;         // L'oggetto di partenza
    public GameObject destinationObject;   // L'oggetto di destinazione
    public GameObject timeTextObject;      // L'oggetto del testo del tempo
    private bool isTeleporting = false;
    private bool isColliding = false; // Aggiungiamo una variabile per tenere traccia della collisione

    void Start()
    {
        // Disattiva l'oggetto di testo all'inizio del gioco
        timeTextObject.SetActive(false);
    }

    void Update()
    {
        if (isTeleporting)
        {
           
            return;
        }

        // Controlla se il giocatore è sopra l'oggetto di partenza
        bool isAboveStartObject = IsPlayerAboveObject(startObject);

        if (isAboveStartObject && !isColliding)
        {
            timeTextObject.SetActive(true);
            isColliding = true;
        }
        else if (!isAboveStartObject)
        {
            timeTextObject.SetActive(false);
            isColliding = false;
        }

        if (isAboveStartObject && Input.GetKeyDown(KeyCode.T))
        {
            // Quando il giocatore preme "T" e sta collidendo con l'oggetto di partenza, esegui il teletrasporto
            TeleportPlayer(destinationObject);
        }
    }

    bool IsPlayerAboveObject(GameObject obj)
    {
        Collider playerCollider = GetComponent<Collider>();
        Collider objectCollider = obj.GetComponent<Collider>();

        if (playerCollider != null && objectCollider != null)
        {
            return playerCollider.bounds.Intersects(objectCollider.bounds);
        }

        return false;
    }

    void TeleportPlayer(GameObject destination)
    {
        isTeleporting = true;

        // Teletrasporta il giocatore all'oggetto di destinazione
        transform.position = destination.transform.position;

        // Imposta una piccola pausa per evitare il teletrasporto continuo se il tasto "T" viene tenuto premuto
        StartCoroutine(ResetTeleportFlag());
    }

    IEnumerator ResetTeleportFlag()
    {
        yield return new WaitForSeconds(0.2f);
        isTeleporting = false;
    }
}

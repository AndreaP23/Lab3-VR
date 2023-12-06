using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrink : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject CocaOnPlayer;

    private bool isPickedUp = false;

    void Start()
    {
        CocaOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void Update()
    {
        if (!isPickedUp && Input.GetKeyDown(KeyCode.V))
        {
            PickUpItem();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isPickedUp)
        {
            PickUpText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpItem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

    private void PickUpItem()
    {
        isPickedUp = true;
        this.gameObject.SetActive(false);
        CocaOnPlayer.SetActive(true);
        PickUpText.SetActive(false);
    }
}

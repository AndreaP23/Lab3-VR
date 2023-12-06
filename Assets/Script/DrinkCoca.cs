using System.Collections;
using UnityEngine;

public class DrinkCoca : MonoBehaviour
{
    public float drinkTime = 10f;
    public float rotationTimeScale = 5f;
    public float delayBeforeDisappear = 5f; // Aggiunto il tempo di attesa prima di sparire
    public Transform drinkingTransform;
    public GameObject drinkableObject;
    public GameObject textDrink;

    private bool isDrinking = false;

    void Start(){
        textDrink.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isDrinking)
        {
            StartCoroutine(DrinkAnimation());
        }
    }

    IEnumerator DrinkAnimation()
    {
        isDrinking = true;

        Vector3 initialPosition = drinkableObject.transform.position;
        Quaternion initialRotation = drinkableObject.transform.rotation;


        float elapsedTime = 0f;

        while (elapsedTime < drinkTime)
        {
            float percentageComplete = elapsedTime / drinkTime;

            drinkableObject.transform.position = Vector3.Lerp(initialPosition, drinkingTransform.position, percentageComplete);
            drinkableObject.transform.rotation = Quaternion.Slerp(initialRotation, drinkingTransform.rotation, percentageComplete * rotationTimeScale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }


        yield return new WaitForSeconds(delayBeforeDisappear);

        // Disattiva l'oggetto al termine dell'attesa
        drinkableObject.SetActive(false);

        // Ripristina la posizione e la rotazione iniziali della lattina
        drinkableObject.transform.position = initialPosition;
        drinkableObject.transform.rotation = initialRotation;

        isDrinking = false;
    }
}
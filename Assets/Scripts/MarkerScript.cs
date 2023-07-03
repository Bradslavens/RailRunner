using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    // Marker trigger string
    public string markerTrigger;

    // Speed of marker movement
    [SerializeField]
    private float speed;

    public TrackTransport trackTransport;

    public QuestionManager questionManager;

    // Property to control if marker is movable
    private bool isMoveable = false;

    private void Start()
    {
        speed = trackTransport.speed;
        StartCoroutine(SetMoveable());
    }

    IEnumerator SetMoveable()
    {
        yield return new WaitForSeconds(3); // wait for 3 seconds
        isMoveable = true;
    }

    void Update()
    {
        // If marker is moveable, then check if current answer equals marker trigger string
        if (isMoveable && questionManager.correctObject.transform.GetChild(0).GetComponent<TextMeshPro>().text == markerTrigger)
        {
            // Move this marker backwards along the Z axis at a given speed
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        // Check if marker's z position has reached the lower bound
        if (transform.position.z <= trackTransport.lowerBound)
        {
            // Deactivate the marker
            gameObject.SetActive(false);
        }
    }
}

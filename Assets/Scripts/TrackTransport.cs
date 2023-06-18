using UnityEngine;

public class TrackTransport : MonoBehaviour
{
    public float speed = 1f; // you can adjust the speed of moving down in Unity inspector
    public float lowerBound = -15f;

    void Update()
    {
        // Move down the object
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // If it reaches y = -15 reset its position to z = 0
        if (transform.position.z <= lowerBound)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 0f);
            transform.position = newPosition;
        }
    }
}

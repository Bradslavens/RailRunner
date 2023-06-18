using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    private int currentTargetIndex = 0;

    // Speed at which the player moves to the target
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(targets[currentTargetIndex].position.x, transform.position.y, transform.position.z),
                speed * Time.deltaTime);
        }
    }

    // You can call this function when you click your left button
    public void MoveLeft()
    {
        if (currentTargetIndex > 0) // check if there's a target to the left
        {
            currentTargetIndex--;
        }
    }

    // You can call this function when you click your right button
    public void MoveRight()
    {
        if (currentTargetIndex < targets.Count - 1) // check if there's a target to the right
        {
            currentTargetIndex++;
        }
    }
}

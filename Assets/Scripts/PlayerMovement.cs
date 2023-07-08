using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    private int currentTargetIndex = 1;

    // Speed at which the player moves to the target
    public float speed = 1f;

    private PlayerAction playerAction;

    void Awake()
    {
        // Initialize your input actions
        playerAction = new PlayerAction();
        playerAction.Movement.MoveLeft.performed += ctx => MoveLeft();
        playerAction.Movement.MoveRight.performed += ctx => MoveRight();
    }

    private void Start()
    {
        MoveToPosition(targets[currentTargetIndex].position.x);
    }


    // You can call this function when you click your left button
    public void MoveLeft()
    {
        Debug.Log("move1 left");

        if (currentTargetIndex > 0)
        {
            currentTargetIndex--;
            Debug.Log(currentTargetIndex);
            MoveToPosition(targets[currentTargetIndex].position.x);
        }
    }

    // You can call this function when you click your right button
    public void MoveRight()
    {
        Debug.Log("move right");

        if (currentTargetIndex < targets.Count - 1) // check if there's a target to the right
        {
            currentTargetIndex++;
            Debug.Log(currentTargetIndex);
            MoveToPosition(targets[currentTargetIndex].position.x);
        }
    }

    private void OnEnable()
    {
        playerAction.Movement.Enable();
    }

    private void OnDisable()
    {
        playerAction.Movement.Disable();
    }

    // Coroutine to move the object
    IEnumerator MoveOverSeconds(float xPosition)
    {
        Vector3 start = transform.position;
        Vector3 end = new Vector3(xPosition, transform.position.y, transform.position.z);
        float elapsedTime = 0;

        while (elapsedTime < speed)
        {
            transform.position = Vector3.Lerp(start, end, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = end;
    }

    // Start the Coroutine to move the player to the position
    private void MoveToPosition(float xPosition)
    {
        StartCoroutine(MoveOverSeconds(xPosition));
    }
}

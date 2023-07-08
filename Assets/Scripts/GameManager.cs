using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public Transform trackTransport;

    public float trackSpeed;
    public float lowerBound;

    public QuestionManager questionManager;

    private Vector3 retPosition;
    public float topPosition = 0f;
    public float bottomPosition = 20f;
    public Transform questionBlocks;
    private GameObject currentObject;

    private bool isMoveable = false;

    // Start is called before the first frame update
    void Start()
    {
        questionManager = GetComponent<QuestionManager>();
        StartCoroutine(Play());
        retPosition = questionBlocks.position;
    }

    void Update()
    {
        // Move down the object
        trackTransport.Translate(Vector3.back * trackSpeed * Time.deltaTime, Space.World);

        // If it reaches y = -15 reset its position to z = 0
        if (trackTransport.position.z <= lowerBound)
        {
            Vector3 newPosition = new Vector3(trackTransport.position.x, trackTransport.position.y, 0f);
            trackTransport.position = newPosition;
        }

        if (isMoveable)
        {
            questionBlocks.Translate(new Vector3(0, 0, -trackSpeed * Time.deltaTime));

        }
    }

    private IEnumerator Play()
    {
        while (true)
        {

            yield return StartCoroutine(questionManager.SetQuestions());
            yield return StartCoroutine(SetBlocks());
            yield return StartCoroutine(ReleaseBlocks());

        }
    }

    private IEnumerator SetBlocks()
    {
        isMoveable = false;
        questionBlocks.position = retPosition;
        Debug.Log("Setting Blocks");
        yield return new WaitForSeconds(3);
    }

    private IEnumerator ReleaseBlocks()
    {
        currentObject = questionManager.correctObject;
        currentObject.SetActive(false);
        Debug.Log("IsMoveable");
        isMoveable = true;
        yield return new WaitForSeconds(3);

        currentObject.SetActive(true);
    }

}

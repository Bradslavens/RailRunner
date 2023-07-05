using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Define enum
    public enum QuizState
    {
        SettingBlocks,
        SettingQuestions,
        QuestionsSet,
        ReleasingBlocks
    }

    // Use the enum to define a variable
    public QuizState currentQuizState;
    public Transform trackTransport;

    public float trackSpeed;
    public float lowerBound;


    public QuestionManager questionManager;

    
    // Start is called before the first frame update
    void Start()
    {
        questionManager = GetComponent<QuestionManager>();
        StartCoroutine(Play());
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
    }

    private IEnumerator Play()
    {
        while(true) 
        {

            yield return StartCoroutine(SetQuizState(QuizState.SettingQuestions, 2f));
            yield return StartCoroutine(SetQuizState(QuizState.SettingBlocks, 2f));
            yield return StartCoroutine(SetQuizState(QuizState.ReleasingBlocks, 2f));

        }
    }

    private IEnumerator SetQuizState(QuizState qs, float duration)
    {
        currentQuizState = qs;
        yield return new WaitForSeconds(duration);
    }
}

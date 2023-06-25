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


    public QuestionManager questionManager;

    
    // Start is called before the first frame update
    void Start()
    {
        questionManager = GetComponent<QuestionManager>();
        StartCoroutine(Play());
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

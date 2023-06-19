using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public AnswerKey answerKey;
    private int currentQuestionNumber = 0;

    void Start()
    {
        string nextAnswer = answerKey.GetCorrectAnswer(currentQuestionNumber);

        if (nextAnswer != null)
        {
            Debug.Log("The answer to the next question is: " + nextAnswer);
            currentQuestionNumber++;
        }
    }
}

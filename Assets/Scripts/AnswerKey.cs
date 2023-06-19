using System.Collections.Generic;
using UnityEngine;

public class AnswerKey : MonoBehaviour
{
    //List to hold the correct answers
    public List<string> correctAnswers = new List<string>();

    public string GetCorrectAnswer(int questionNumber)
    {
        if (questionNumber < 0 || questionNumber >= correctAnswers.Count)
        {
            Debug.LogError("Question number is out of range!");
            return null;
        }
        else
        {
            return correctAnswers[questionNumber];
        }
    }

}

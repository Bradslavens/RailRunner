using System;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public AnswerKey answerKey;
    private int currentQuestionNumber = 0;
    public RandomObjectSelector randomObjectSelector;
    private GameObject correctObject;
    void Start()
    {
        string nextAnswer = answerKey.GetCorrectAnswer(currentQuestionNumber);

        if (nextAnswer != null)
        {
            Debug.Log("The answer to the next question is: " + nextAnswer);
            correctObject =  randomObjectSelector.GetRandomObject();
            Debug.Log("the new answer is " + ReplaceLastTwoCharacters(nextAnswer));
            currentQuestionNumber++;
        }
    }

    private string ReplaceLastTwoCharacters(string original)
    {
        // Ensure the original string is long enough
        if (original.Length < 2)
        {
            throw new ArgumentException("Original string must have at least two characters");
        }

        // Take the last character of the original string
        char lastChar = original[original.Length - 1];
        // Calculate the next even number after it (if it's a digit)
        int nextEven = -1;
        if (Char.IsDigit(lastChar))
        {
            int lastDigit = (int)Char.GetNumericValue(lastChar);
            nextEven = lastDigit + (lastDigit % 2 == 0 ? 2 : 1);
        }
        else
        {
            throw new ArgumentException("The last character of the string must be a digit");
        }

        // Take the second last character of the original string
        char secondLastChar = original[original.Length - 2];
        // Calculate the next even number after it (if it's a digit)
        int secondNextEven = -1;
        if (Char.IsDigit(secondLastChar))
        {
            int secondLastDigit = (int)Char.GetNumericValue(secondLastChar);
            secondNextEven = secondLastDigit + (secondLastDigit % 2 == 0 ? 2 : 1);
        }
        else
        {
            throw new ArgumentException("The second last character of the string must be a digit");
        }

        // Build the new string by keeping all characters of the original string except the last two, 
        // then adding the new even numbers.
        string newString = original.Substring(0, original.Length - 2) + secondNextEven.ToString() + nextEven.ToString();

        return newString;
    }
}

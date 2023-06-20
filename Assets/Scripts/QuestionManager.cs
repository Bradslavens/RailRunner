using System;
using TMPro;
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

            // assign the next answer to the correct object 
            correctObject.transform.GetChild(1).GetComponent<TextMeshPro>().text = nextAnswer;
            Debug.Log(" bb " + correctObject.name);
            foreach (GameObject obj in randomObjectSelector.gameObjects) {
                if(obj != correctObject)
                {
                    obj.transform.GetChild(1).GetComponent<TextMeshPro>().text = ReplaceLastTwoCharacters(nextAnswer); ;
                }
            
            }
            //Debug.Log("the new answer is " + ReplaceLastTwoCharacters(nextAnswer));
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
        string nextEven;
        if (Char.IsDigit(lastChar))
        {
            nextEven = UnityEngine.Random.Range(0, 10).ToString();
        }
        else
        {
            int randomLetter = UnityEngine.Random.Range(0, 2);
            
            if(randomLetter == 0)
            {
                nextEven = "A";
            }
            else
            {
                nextEven= "B";
            }
        }

        // Take the second last character of the original string
        char secondLastChar = original[original.Length - 2];
        string secondNextEven;

        if (Char.IsDigit(secondLastChar))
        {
            secondNextEven = UnityEngine.Random.Range(0, 10).ToString();
        }
        else
        {
            int randomLetter = UnityEngine.Random.Range(0, 2);

            if (randomLetter == 0)
            {
                secondNextEven = "L";
            }
            else
            {
                secondNextEven = "R";
            }
        }

        // Build the new string by keeping all characters of the original string except the last two, 
        // then adding the new even numbers.
        string newString = original.Substring(0, original.Length - 2) + secondNextEven + nextEven;

        return newString;
    }
}

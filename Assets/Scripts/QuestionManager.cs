using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public AnswerKey answerKey;
    private int currentQuestionNumber = 0;
    public RandomObjectSelector randomObjectSelector;
    public GameObject correctObject;
    [SerializeField]
    private List<char> possibleCharacters;
    [SerializeField]
    private Vector3 retPos;
    public GameManager gameManager;

    void Awake()
    {
        if (possibleCharacters == null || possibleCharacters.Count == 0)
        {
            Debug.LogError("No possible characters have been provided!");
        }
    }

    void Start()
    {
        SetQuestions();

    }

    //private void Update()
    //{
    //    if(gameManager.resetQuestions)
    //    {
    //        Debug.Log("reset questions");
    //        SetQuestions();
    //        gameManager.resetQuestions = false;
    //    }

    //}

    public void SetQuestions()
    {
        string nextAnswer = answerKey.GetCorrectAnswer(currentQuestionNumber);

        if (nextAnswer != null)
        {
            Debug.Log("The answer to the next question is: " + nextAnswer);
            correctObject = randomObjectSelector.GetRandomObject();

            // assign the next answer to the correct object 
            correctObject.transform.GetChild(1).GetComponent<TextMeshPro>().text = nextAnswer;
            Debug.Log(" bb " + correctObject.name);
            foreach (GameObject obj in randomObjectSelector.gameObjects)
            {
                if (obj != correctObject)
                {
                    obj.transform.GetChild(1).GetComponent<TextMeshPro>().text = GenerateRandomString(nextAnswer.Length);
                }

            }
            //Debug.Log("the new answer is " + ReplaceLastTwoCharacters(nextAnswer));
            currentQuestionNumber++;
        }

    }

        public string GenerateRandomString(int length)
    {
        string result = "";
        System.Random random = new System.Random();

        for (int i = 0; i < length; i++)
        {
            // Select a random character from the list
            char randomChar = possibleCharacters[random.Next(possibleCharacters.Count)];
            result += randomChar;
        }

        return result;
    }

    private string ReplaceLastTwoCharacters(string original)
    {
        string newString;

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
            nextEven = (2*UnityEngine.Random.Range(0, 5)).ToString();
        }
        else
        {
            newString = HandleMixedNames(original);
            return newString;
        }

        // Take the second last character of the original string
        char secondLastChar = original[original.Length - 2];
        string secondNextEven = "a";

        if (Char.IsDigit(secondLastChar))
        {
            secondNextEven = UnityEngine.Random.Range(0, 5).ToString();
        }
        else
        {
            newString = HandleMixedNames(original);
        }

        // Build the new string by keeping all characters of the original string except the last two, 
        // then adding the new even numbers.
        newString = original.Substring(0, original.Length - 2) + secondNextEven + nextEven;

        return newString;
    }

    private string HandleMixedNames(string original)
    {
        return "HHH";
    }
}

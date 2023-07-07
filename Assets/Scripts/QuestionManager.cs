using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public AnswerKey answerKey;
    private int currentQuestionNumber = 0;
    public RandomObjectSelector randomObjectSelector;
    public GameObject correctObject;
    [SerializeField]
    private List<char> possibleAlphaCharacters;
    [SerializeField]
    private List<char> possibleNumericCharacters;
    [SerializeField]
    private Vector3 retPos;
    public GameManager gameManager;

    void Awake()
    {
        if (possibleAlphaCharacters == null || possibleAlphaCharacters.Count == 0)
        {
            Debug.LogError("No possible characters have been provided!");
        }


        if (possibleNumericCharacters == null || possibleNumericCharacters.Count == 0)
        {
            Debug.LogError("No possible characters have been provided!");
        }
    }



    public IEnumerator SetQuestions()
    {
        string nextAnswer = answerKey.GetCorrectAnswer(currentQuestionNumber);

        if (nextAnswer != null)
        {
            Debug.Log("The answer to the next question is: " + nextAnswer);
            correctObject = randomObjectSelector.GetRandomObject();
            //Debug.Log("co " + correctObject.transform.GetChild;

            // assign the next answer to the correct object 
            correctObject.transform.GetChild(0).GetComponent<TextMeshPro>().text = nextAnswer;  // set child number the same below
            foreach (GameObject obj in randomObjectSelector.gameObjects)
            {
                if (obj != correctObject)
                {
                    obj.transform.GetChild(0).GetComponent<TextMeshPro>().text = GenerateRandomString(nextAnswer);
                }

            }
            //Debug.Log("the new answer is " + ReplaceLastTwoCharacters(nextAnswer));
            currentQuestionNumber++;
        }
        yield return null;

    }

    public string GenerateRandomString(string nextAnswer)
    {
        string result = "";
        System.Random random = new System.Random();

        int i = 0;

        foreach(char c in nextAnswer)
        {        
            Debug.Log(" char = " + c.ToString());

            if(i < 2)
            {
                result += c.ToString();
                i++;
            }
            else if (char.IsDigit(c))
            {
                result += possibleNumericCharacters[random.Next(possibleNumericCharacters.Count)].ToString();
                i++;
            } else if (char.IsLetter(c))
            {
                result += possibleAlphaCharacters[random.Next(possibleAlphaCharacters.Count)].ToString();
                i++;
            }
        }

        Debug.Log(result + " result ");
        return result;
    }

   
}

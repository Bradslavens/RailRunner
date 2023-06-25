using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CheckAnswers = false;
    public bool setObjects = false;
    public bool resetQuestions = false;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckAnswerRoutine());
    }

    IEnumerator CheckAnswerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            CheckAnswers = true;
            // Perform your answer checking logic here

            yield return new WaitForSeconds(3f);  // Wait for one frame
            setObjects = true;
            resetQuestions = true;
        }
    }
}

using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CheckAnswers = false;

    
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

            //yield return null;  // Wait for one frame
            //CheckAnswers = false;
        }
    }
}

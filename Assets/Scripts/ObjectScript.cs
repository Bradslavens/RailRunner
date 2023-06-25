using Unity.VisualScripting;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public float Speed = 10f;
    private GameManager gameManager;
    private QuestionManager questionManager;
    private Vector3 retPosition;
    bool isMoveable = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questionManager = gameManager.GetComponent<QuestionManager>();

        retPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentQuizState == GameManager.QuizState.SettingBlocks)
        {
            transform.position = retPosition;
            isMoveable = false;
        }
        else if (gameManager.currentQuizState == GameManager.QuizState.ReleasingBlocks && (gameObject.name != questionManager.correctObject.name))
        {
            isMoveable = true;

        }
        
        if (isMoveable)
        {
            transform.Translate(new Vector3(0, 0, -Speed * Time.deltaTime));

        }


    }
}

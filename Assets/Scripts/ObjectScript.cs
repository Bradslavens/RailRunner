using Unity.VisualScripting;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public float Speed = 10f;
    private GameManager gameManager;
    private QuestionManager questionManager;
    //private TrackTransport trackTransport;
    private Vector3 retPosition;
    [SerializeField]
    private float lowerBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questionManager = gameManager.GetComponent<QuestionManager>();
        //trackTransport = GameObject.Find("TrackTransport").GetComponent<TrackTransport>();

        retPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CheckAnswers && gameObject.name != questionManager.correctObject.name)
        {
            transform.Translate(new Vector3(0, 0, -Speed * Time.deltaTime));          

        }

        if (transform.position.z <= lowerBound)
        {
            Debug.Log(" lower bound " + lowerBound + " z " + transform.position.z);
            //gameManager.CheckAnswers = false;
            transform.position = retPosition;
        }
    }
}

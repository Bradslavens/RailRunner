using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public float Speed = 10f;
    private GameManager gameManager;
    private QuestionManager questionManager;
    private TrackTransport trackTransport;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questionManager = gameManager.GetComponent<QuestionManager>();
        trackTransport = GameObject.Find("TrackTransport").GetComponent<TrackTransport>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CheckAnswers && this.gameObject != questionManager.correctObject)
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, -Speed * Time.deltaTime));
            if(this.gameObject.transform.position.z < trackTransport.lowerBound)
            {
                Destroy(this.gameObject);
                gameManager.CheckAnswers = false;
            }

        }
    }
}

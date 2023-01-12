using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public string grabableTag = "Grabable";
    public Transform endzone;
    public float fastestDistance;
    public GameObject scorePanel;
    public Text scoreText;
    public float travelledDistance;
    private Vector3 startingPosition;
    public float score;
    public float decayRate = 0.1f;  // Rate of decay per second

    private void Start()
    {
        // Store the starting position of the player
        startingPosition = transform.position;
        //Find all the items in the scene with the grabableTag
        GameObject[] grabableItems = GameObject.FindGameObjectsWithTag(grabableTag);
        // Assign the distance from start to end zone through all the grabable items to the variable fastestDistance
        fastestDistance = Vector3.Distance(transform.position, endzone.position);
        for (int i = 0; i < grabableItems.Length; i++)
        {
            fastestDistance += Vector3.Distance(grabableItems[i].transform.position, grabableItems[i == grabableItems.Length - 1 ? 0 : i + 1].transform.position);
        }
    }

    private void Update()
    {
        // Calculate the traveled distance
        travelledDistance += Vector3.Distance(transform.position, startingPosition);
        startingPosition = transform.position;

        // Check if the fastestDistance is zero before calculating the score
        if (fastestDistance != 0)
        {
            score = 1 / (travelledDistance / fastestDistance) * 100;
            //decrement the score by the decay rate per second
            score -= decayRate * Time.deltaTime;
            score = Mathf.Max(score, 0);
            score = Mathf.Min(score, 100); // Keep the score at a maximum of 100
        }
        else
        {
            score = 0;
        }

        scoreText.text = "Score: " + score.ToString("0.00");
        // if all the grabable items are not present, enable the score panel
        if (GameObject.FindGameObjectsWithTag(grabableTag).Length == 0)
        {
            scorePanel.SetActive(true);
        }
    }
}

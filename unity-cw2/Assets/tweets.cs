using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tweets : MonoBehaviour
{
    public Transform interactorSource;
    public float interactionDistance;
    public GameObject intText;
    public Material[] tweetMaterials;
    private int currentTweetIndex = 0;
    private int playerScore = 0;
    public bool gameOver = false;

    public GameObject shape;
    public Text scoreText; // Reference to the UI text element

    void Start()
    {
        intText.SetActive(false);
        scoreText.gameObject.SetActive(false); // Initially, hide the score text
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "machine")
            {
                tweetMaterials = Resources.LoadAll<Material>("tweetsFolder");

                foreach (Material material in tweetMaterials)
                {
                    //Debug.Log("Material Name: " + material.name);
                }

                intText.SetActive(true);
                scoreText.gameObject.SetActive(true); // Show the score text when near the machine

                if (Input.GetKeyDown(KeyCode.F))
                {
                    CheckTweet('F');
                    DisplayTweet();
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    CheckTweet('R');
                    DisplayTweet();
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    currentTweetIndex = -1;
                    playerScore = 0;
                    gameOver = false;

                    DisplayTweet();
                }
            }
        }
        else
        {
            intText.SetActive(false);
            scoreText.gameObject.SetActive(false); // Hide the score text when not near the machine
        }

        // Update the score text
        scoreText.text = "Score: " + playerScore;
    }

    void DisplayTweet()
    {
        if (currentTweetIndex < tweetMaterials.Length - 1)
        {
            shape.GetComponent<Renderer>().material = tweetMaterials[currentTweetIndex + 1];
            currentTweetIndex++;
        }
        else
        {
            Debug.Log("All tweets displayed. Game Over! You score: " + playerScore);
            gameOver = true;
            // You can handle what happens when all tweets are displayed
        }
    }

    void CheckTweet(char playerPick)
    {



        if (!gameOver)
        {
            Debug.Log("current Index: " + currentTweetIndex);

            string currentMaterialName = tweetMaterials[currentTweetIndex].name;

            bool isReal = currentMaterialName.ToLower().Contains("real");

            Debug.Log("MatName: " + currentMaterialName + " IsReal: " + isReal);

            if (isReal && playerPick == 'R')
            {
                Debug.Log("Correct! The tweet is real.");
                playerScore += 1;
            }
            else if (!isReal && playerPick == 'F')
            {
                Debug.Log("Correct! The tweet is fake.");
                playerScore += 1;
            }
            else
            {
                Debug.Log("Wrong choice, no score.");
            }
        }
    }
}

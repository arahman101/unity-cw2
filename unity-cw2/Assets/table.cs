using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table : MonoBehaviour
{
        // The two letters to choose between
    public char increaseSizeKey = 'E';
    public char decreaseSizeKey = 'R';

    // Adjust these values based on how much you want to change the size
    public float sizeIncreaseAmount = 0.1f;
    public float sizeDecreaseAmount = 0.1f;

    // Reference to the shape on the table
    public GameObject shape;

    // Boolean to check if the player is near the table
    private bool isPlayerNearTable = false;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("On Update");

        // Check if the player is near the table and is pressing a key
        if (isPlayerNearTable && Input.GetKeyDown("E"))
        {
            IncreaseSize();
        }
        else if (isPlayerNearTable && Input.GetKeyDown("R"))
        {
            DecreaseSize();
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            isPlayerNearTable = true;
            Debug.Log("Press " + increaseSizeKey + " to increase size, " + decreaseSizeKey + " to decrease size.");
        }
    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            isPlayerNearTable = false;
        }
    }

    // Function to increase the size of the shape
    void IncreaseSize()
    {
        Debug.Log("E Key Pressed");
        // Adjust the scale of the shape
        shape.transform.localScale += new Vector3(sizeIncreaseAmount, sizeIncreaseAmount, sizeIncreaseAmount);
    }

    // Function to decrease the size of the shape
    void DecreaseSize()
    {

        Debug.Log("R Key Pressed");
        // Ensure the shape does not become too small
        if (shape.transform.localScale.x > sizeDecreaseAmount &&
            shape.transform.localScale.y > sizeDecreaseAmount &&
            shape.transform.localScale.z > sizeDecreaseAmount)
        {
            // Adjust the scale of the shape
            shape.transform.localScale -= new Vector3(sizeDecreaseAmount, sizeDecreaseAmount, sizeDecreaseAmount);
        }
    }
    


}





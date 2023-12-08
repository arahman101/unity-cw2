using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class interactor : MonoBehaviour
{

    public Transform interactorSource;
    public float interactRange;
    public GameObject increaseSizeText;


    // Adjust these values based on how much you want to change the size
    public float sizeIncreaseAmount = 0.1f;
    public float sizeDecreaseAmount = 0.1f;
    public float moveSphereDistance = 0.4f;
    public float minSize = 0.7f;
    public float maxSize = 5.0f;
    private bool shouldSpin = false;
    private bool spinningInitiated = false;
    float epsilon = 0.0001f; // Small epsilon value to handle precision errors
    GameObject newSphere;
    GameObject newSphere2;
    GameObject newSphere3;
    public int numOfSpheres = 1;


    public float rotationSpeed = 30f; // rotation speed




    // Reference to the shape on the table
    public GameObject shape;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {

            if (hit.collider.gameObject.tag == "table")
            {
                increaseSizeText.SetActive(true);
                


                if (Input.GetKeyDown(KeyCode.E))
                {
                    IncreaseSize();

                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    DecreaseSize();

                }
                else if (Input.GetKeyDown(KeyCode.T))
                {
                    shouldSpin = !shouldSpin; // Toggle the spinning state when 'T' is pressed
                    spinningInitiated = shouldSpin; // Set the flag when spinning is initiated
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    rotationSpeed *= 1.5f; // Multiply rotationSpeed by 1.5 and assign the result back to rotationSpeed



                }else if (Input.GetKeyDown(KeyCode.Z))
                {
                    rotationSpeed /= 1.5f;
                }
                                else if (Input.GetKeyDown(KeyCode.C))
                {
                    CreateNewSphere(); // Call the function to create a new sphere
                }

                if (spinningInitiated)
                {
                    spinShape();
                }
            } 
            else
            {
                //increaseSizeText.SetActive(false);

            }


        }
        else
        {
            increaseSizeText.SetActive(false);
        }
    }

    // Function to increase the size of the shape
    void IncreaseSize()
    {


        if (!(shape.transform.localScale.z > 1))
        {


            // Save the current position before making any changes
            Vector3 currentPosition = shape.transform.position;

            // Adjust the scale of the shape
            shape.transform.localScale += new Vector3(sizeIncreaseAmount, sizeIncreaseAmount, sizeIncreaseAmount);

            // Calculate the difference in position caused by scaling
            Vector3 positionOffset = shape.transform.position - currentPosition;

            // Adjust the position to counteract the scaling effect
            shape.transform.position -= positionOffset;

            // Increase the y-position by 0.1
            shape.transform.position += new Vector3(0.0f, 0.0f, moveSphereDistance);
        }

    }

    // Function to decrease the size of the shape
    void DecreaseSize()
    {

        // Ensure the shape does not become too small
        Debug.Log("before the if size: " + shape.transform.localScale.z);

        if (shape.transform.localScale.z > (0.1f + epsilon))

        {
            Debug.Log("Size is not more than 0.1f: " + shape.transform.localScale.z);
            if (shape.transform.localScale.x > sizeDecreaseAmount &&
             shape.transform.localScale.y > sizeDecreaseAmount &&
            shape.transform.localScale.z > sizeDecreaseAmount)
            {
                // Adjust the scale of the shape
                shape.transform.localScale -= new Vector3(sizeDecreaseAmount, sizeDecreaseAmount, sizeDecreaseAmount);
                shape.transform.position += new Vector3(0.0f, 0.0f, -moveSphereDistance);
            }
            // Clamp the scale to stay within the specified limits

        }
    }

    void spinShape()
    {
        // Adjust the rotation speed based on your requirements

        // Rotate the shape continuously around its Y-axis
        shape.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        if (newSphere)
        {
            newSphere.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        }
        if (newSphere2)
        {
            newSphere.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
            newSphere2.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        }
        if (newSphere3)
        {
            newSphere2.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
            newSphere3.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        }
    }
    // Function to create a new sphere
    void CreateNewSphere()
    {

        if (numOfSpheres == 1)
        {


            // Instantiate a new sphere based on the prefab
            newSphere = Instantiate(shape, shape.transform.position + new Vector3(0f, 0f, 2f), Quaternion.identity);

            // Optionally, you can set additional properties of the new sphere if needed
            newSphere.GetComponent<Renderer>().material.color = Random.ColorHSV();
            numOfSpheres += 1;

            // If you want to interact with the new sphere, you may need to adjust the reference accordingly
        }
        else if (numOfSpheres == 2)
        {
            // Instantiate a new sphere based on the prefab
            newSphere2 = Instantiate(shape, shape.transform.position + new Vector3(0f, 0f, 2f), Quaternion.identity);
            numOfSpheres += 1;

            // Optionally, you can set additional properties of the new sphere if needed
            newSphere2.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }else if (numOfSpheres == 3)
        {
            newSphere3 = Instantiate(shape, shape.transform.position + new Vector3(0f, 0f, 2f), Quaternion.identity);
            newSphere3.GetComponent<Renderer>().material.color = Random.ColorHSV();
            numOfSpheres += 1;

        }
    }

}

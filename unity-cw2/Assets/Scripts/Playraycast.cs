using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playraycast : MonoBehaviour
{
    public int raylength;
    private VideoPlayBack raycastedObj;
    [SerializeField] private KeyCode vidKey = KeyCode.E;
    private const string interactableTag = "play";
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position,fwd, out hit, raylength))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                raycastedObj = hit.collider.gameObject.GetComponent<VideoPlayBack>();
                if (Input.GetKeyDown(vidKey))
                {
                    raycastedObj.PlayPause();
                }
            }
        }
    }
}

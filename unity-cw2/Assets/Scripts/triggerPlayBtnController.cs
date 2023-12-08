using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPlayBtnController : MonoBehaviour
{
    [SerializeField] private GameObject intText;
     [SerializeField] private bool openTrigger = false;
     private VideoPlayBack videoPlayBack;

     void Start(){
        videoPlayBack = gameObject.AddComponent<VideoPlayBack>();
     }

     private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                intText.SetActive(true);
                Debug.Log("Trigger Activated");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    videoPlayBack.PlayPause();
                    Debug.Log("Key pressed");
                }
            }
            else {
                intText.SetActive(false);
            }
        }
     }
}


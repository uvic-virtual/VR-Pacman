using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickUpObject : MonoBehaviour {

    [SerializeField] private SteamVR_Action_Boolean button;
    [SerializeField] private SteamVR_Input_Sources hand;

    private bool holding;
    private GameObject collidingObj;

    void Start()
    {
        collidingObj = null;
        holding = false;
    }
    void Update()
    {
        if(button.GetStateDown(hand) && holding)
        {
            holding = false;
            collidingObj.GetComponent<Rigidbody>().useGravity = true;
            collidingObj.GetComponent<Rigidbody>().isKinematic = false;
            collidingObj.transform.parent = null;
            collidingObj = null;
        }
        else if (button.GetStateDown(hand) && collidingObj!= null &&!holding)
        {
            //pick up an object
            holding = true;
            collidingObj.GetComponent<Rigidbody>().useGravity = false;
            collidingObj.GetComponent<Rigidbody>().isKinematic = true;
            collidingObj.transform.parent = gameObject.transform;
            //collidingObj.transform.localPosition = new Vector3(1, 0, 1);
            //collidingObj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickupable" && !holding)
        {
            collidingObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidingObj != null && other.gameObject.tag == "Pickupable" && !holding)
        {
            collidingObj = null;
        }
    }

}

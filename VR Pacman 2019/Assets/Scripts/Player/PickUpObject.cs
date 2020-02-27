using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickUpObject : MonoBehaviour {

    [SerializeField] private SteamVR_Action_Boolean button;
    [SerializeField] private SteamVR_Input_Sources hand;
    private bool holding;
    //the object the player is holding
    private GameObject obj;

    void Start()
    {

        obj = null;
        holding = false;
    }
    void Update()
    {
    }
    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log(Collider.gameObject.tag);
        if (obj != null && button.GetLastStateDown(hand))
        {
            //break connection
            holding = false;
            obj.transform.parent = null;
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj = null;
        }

       
        else if (Collider.gameObject.tag == "Pickupable" && button.GetStateDown(hand) && !holding)
        {
            Debug.Log("pick");
            obj = Collider.gameObject;
            holding = true;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition = new Vector3(1, 0, 1);
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }   
    }
}

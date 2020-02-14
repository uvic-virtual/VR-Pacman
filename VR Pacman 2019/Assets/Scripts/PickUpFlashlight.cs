using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {
 


    void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<Rigidbody>().useGravity = false;
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.parent = Collider.transform;
            gameObject.transform.localPosition = new Vector3(1, 0, 1);
            gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0);

        }   
    }
}

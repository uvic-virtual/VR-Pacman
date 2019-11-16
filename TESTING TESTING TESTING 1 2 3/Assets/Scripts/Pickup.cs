using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PickupOrb")){
			other.gameObject.SetActive (false);
		}
	}
}
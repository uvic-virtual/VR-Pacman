using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour {

	private int count;
	public Text countText;
	void Start (){
		count = 0;
		SetCountText();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PickupOrb")){
			other.gameObject.SetActive (false);
			count = count + 10;
			SetCountText();
		}
	}
	void SetCountText (){
		countText.text = "Count: " + count.ToString ();
	}
}
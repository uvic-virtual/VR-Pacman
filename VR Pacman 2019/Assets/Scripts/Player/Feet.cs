using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour {
	private GameObject playerFeet;
	private GameObject playerCam;
	// Use this for initialization
	void Start () {
		playerFeet = GameObject.Find("PlayerFeet");
		playerCam = GameObject.Find("PlayerCam");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camPos = playerCam.transform.position;
		Vector3 feetPos = new Vector3(camPos.x, camPos.y - 1.5f, camPos.z);
		playerFeet.transform.position = feetPos;
	}
}

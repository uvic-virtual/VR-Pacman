using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour {
	[SerializeField] float playerHight = 1.5f;

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
		Vector3 feetPos = new Vector3(camPos.x, camPos.y - playerHight, camPos.z);
		playerFeet.transform.position = feetPos;
	}
}

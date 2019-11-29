using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCursorFollow : MonoBehaviour {

	//private GameObject obj1;
	public Transform obj1;

	void start(){
		//obj1 = GameObject.FindWithTag("PlayerCamera");
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("obj1: " + obj1);	//This outputs what obj1 is called. Used to test if obj1 was set properly
		transform.rotation =
		Quaternion.Euler(-90, obj1.transform.eulerAngles.y, 180);
	}
}

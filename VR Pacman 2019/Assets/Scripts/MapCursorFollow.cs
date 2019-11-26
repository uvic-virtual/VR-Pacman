using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCursorFollow : MonoBehaviour {

	public Transform obj1;
	public Transform obj2;


	// Update is called once per frame
	void Update () {
		obj2.rotation = Quaternion.Euler(-90, obj1.eulerAngles.y, 180);
	}
}

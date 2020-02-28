using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "PlayerCam")
		{
			SceneManager.LoadScene("0.Menu");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

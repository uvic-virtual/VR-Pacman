using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	private Canvas HUD;
	// Use this for initialization
	void Start () {
		HUD = GameObject.Find("HUD").GetComponent<Canvas>();
		HUD.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -15)
		{
			HUD.enabled = false;
			SceneManager.LoadScene("1.Game");
		}
	}
}

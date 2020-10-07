using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public Text finalTime;

	// Use this for initialization
	void Start () {
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "PlayerFeet")
		{
			finalTime = GameObject.Find("Player").GetComponent<Timer>().timerText;
			SceneManager.LoadScene("0.Menu");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

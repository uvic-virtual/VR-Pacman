using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	private Canvas HUD;
	private GameObject player;
	[SerializeField] private GameObject floor;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		HUD = GameObject.Find("HUD").GetComponent<Canvas>();
		HUD.enabled = false;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Coin")
		{
            StartCoroutine(FindObjectOfType<AudioManager>().Play("Insert_Coin"));
            Destroy(other.gameObject);
			Destroy(floor);
		}
	}


	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < -15)
		{
			HUD.enabled = true;
			SceneManager.LoadScene("1.Game");
		}
	}
}

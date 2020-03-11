using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "PlayerFeet")
		{
            this.GetComponent<AudioSource>().Stop();
            FindObjectOfType<AudioManager>().Stop("Creepy_Background_Music");
            StartCoroutine(FindObjectOfType<AudioManager>().Play("Death", 0.5f));
            StartCoroutine(DelaySceneLoad());
		}
	}

    //A delay so that the scene will end after the death sound
	private IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("0.Menu");
    }
}

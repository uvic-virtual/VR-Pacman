using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Pickup : MonoBehaviour
{
    public float PowerupDelay = 15;
    public int remaining_pickups = 10;
    
    //Events for ghosts
    public delegate void GhostMethod();
    public event GhostMethod Powerup;
    public event GhostMethod Powerdown;

    public Text ScoreText;

    private static int Score = 0;

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickupOrb"))
        {
            Destroy(other.gameObject);
            Score += 10;
            ScoreText.text = "Score: " + Score.ToString();
            remaining_pickups--;
		}
        else if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            StartCoroutine("FruitRoutine");
            remaining_pickups--;
        }
        if(remaining_pickups == 0)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
        Debug.Log(remaining_pickups);
	}

    private IEnumerator FruitRoutine()
    {
        if (Powerup != null)
        {
            Powerup();
        }
        yield return new WaitForSeconds(PowerupDelay);
        if (Powerdown != null)
        {
            Powerdown();
        }
    }
}
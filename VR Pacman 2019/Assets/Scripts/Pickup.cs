using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public float PowerupDelay = 15;
    public int remainingPickups = 168;

    //Events for ghosts
    public delegate void GhostMethod();
    public static event GhostMethod Powerup;
    public static event GhostMethod Powerdown;

    public Text scoreText;
    public Text levelText;

    private static int score = 0;
    private static int level = 1;
    
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        levelText.text = "Level: " + level.ToString();
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickupOrb"))
        {
            Destroy(other.gameObject);
			score = score + 10;
            remainingPickups--;
		}
        else if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            StartCoroutine("FruitRoutine");
            remainingPickups--;
        }
        if (remaining_pickups == 0)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            Level++;
        }
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
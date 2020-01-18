using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public float PowerupDelay = 15;
    public int RemainingPickups = 168;

    //Events for ghosts
    public delegate void GhostMethod();
    public static event GhostMethod Powerup;
    public static event GhostMethod Powerdown;

    public Text scoreText;
    public Text levelText;

    private static int Score = 0;
    private static int Level = 1;
    
    void Update()
    {
        scoreText.text = "Score: " + Score.ToString();
        levelText.text = "Level: " + Level.ToString();
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickupOrb"))
        {
            Destroy(other.gameObject);
			Score = Score + 10;
            RemainingPickups--;
		}
        else if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            StartCoroutine("FruitRoutine");
            RemainingPickups--;
        }
        if (RemainingPickups == 0)
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
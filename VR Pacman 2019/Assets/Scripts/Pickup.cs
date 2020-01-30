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

    public Text ScoreText;
    public Text LevelText;

    private static int Score = 0;
    private static int Level = 1;
    
    void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        LevelText.text = "Level: " + Level.ToString();
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
        else if (other.gameObject.CompareTag("Fruit"))
        {
            if (Level == 1) { Score += 100; }
            else if (Level == 2) { Score += 300; }
            else if (Level == 3) { Score += 500; }
            else if (Level == 4) { Score += 700; }
            else if (Level == 5) { Score += 1000; }
            else if (Level == 6) { Score += 2000; }
            else if (Level == 7) { Score += 3000; }
            else if (Level > 7) { Score += 5000; }
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

    public static int getLevel()
    {
        return Level;
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PickUpFruits : MonoBehaviour
{
    public float PowerupDelay = 15;
    public int RemainingPickups = 168;

    //Events for ghosts
    public delegate void GhostMethod();
    public static event GhostMethod Powerup;
    public static event GhostMethod Powerdown;

    private Text ScoreText;
    private Text LevelText;

    private static int Score = 0;
    private static int Level = 1;

    void Start()
    {
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        LevelText = GameObject.Find("Level").GetComponent<Text>();
    }

    void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        LevelText.text = "Level: " + Level.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupOrb"))
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play("Waka")); 
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
            StartCoroutine(FindObjectOfType<AudioManager>().Play("Fruit"));
            switch (Level)
            {
                case 1:
                    Score += 100;
                    break;
                case 2:
                    Score += 300;
                    break;
                case 3:
                    Score += 500;
                    break;
                case 4:
                    Score += 700;
                    break;
                case 5:
                    Score += 1000;
                    break;
                case 6:
                    Score += 2000;
                    break;
                case 7:
                    Score += 3000;
                    break;
                default:
                    Score += 5000;
                    break;
            }
        }
        if (RemainingPickups == 0)
        {
            //StartCoroutine(FindObjectOfType<AudioManager>().Play("Intermission"));
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
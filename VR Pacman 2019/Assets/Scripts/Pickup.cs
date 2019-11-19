using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    public Text countText;

    private int Count
    {
        get { return _count;  }

        set
        {
            _count = value;
            countText.text = "Count: " + _count.ToString();
        }
    }
    private int _count;

    void Start ()
    {
		Count = 0;
	}

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickupOrb"))
        {
            Destroy(other.gameObject);
			Count = Count + 10;
		}
	}
}
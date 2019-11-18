using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	public Transform Teleport1;
	public GameObject Player;

	void OnTriggerEnter(Collider other)
	{
		Player.transform.position = Teleport1.transform.position;
	}
}